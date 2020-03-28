using BBIT.DAL.Context;
using Interfaces.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BBIT.Domain.Entities.Auth.Identity.User;
using BBIT.Domain.Entities.Auth.JWT;
using BBIT.Domain.Entities.Auth.JWT.Settings;
using BBIT.Domain.Entities.DTO.Auth;
using Services.Data.DefaultDataInitialization.Auth;

namespace Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly BBITContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(
            UserManager<AppUser> userManager,
            JwtSettings jwtSettings,
            TokenValidationParameters tokenValidationParameters,
            BBITContext context,
            RoleManager<IdentityRole> roleManager,
            ILogger<AuthenticationService> logger)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _context = context;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<AuthenticationDto> RegisterAsync(string email, string password, string name)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
                return new AuthenticationDto { Errors = new[] { "User with this email address already exists" } };

            var newUserGuid = Guid.NewGuid();
            var newUser = new AppUser
            {
                Id = newUserGuid.ToString(),
                Email = email,
                UserName = email,
                Name = name
            };

            var created = await _userManager.CreateAsync(newUser, password);
            if (!created.Succeeded)
                return new AuthenticationDto { Errors = created.Errors.Select(x => x.Description) };

            await _userManager.AddToRoleAsync(newUser, DefaultIdentity.RoleUser);

            return await GenerateAuthenticationResultForUserAsync(newUser);
        }

        public async Task<AuthenticationDto> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                _logger.LogWarning($"[AUTH FAILED] Email: {email}");
                return new AuthenticationDto { Errors = new[] { "User does not exist" }, CriticalError = false };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
            {
                _logger.LogWarning($"[AUTH FAILED] Email: {email}");
                return new AuthenticationDto { Errors = new[] { "Password is incorrect" }, CriticalError = false };
            }

            _logger.LogInformation($"[User: {user.Email} Id: {user.Id}] Successfully logged in");
            return await GenerateAuthenticationResultForUserAsync(user);
        }

        public async Task<AuthenticationDto> RefreshTokenAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);

            if (validatedToken is null)
                return new AuthenticationDto { Errors = new[] { "Invalid Token" }, CriticalError = true };

            var expiryDateUnix =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            var storedRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);

            if (storedRefreshToken is null)
                return new AuthenticationDto { Errors = new[] { "This refresh token does not exist" }, CriticalError = true };

            if (storedRefreshToken.Invalidated)
                return new AuthenticationDto { Errors = new[] { "This refresh token has been invalidated" }, CriticalError = true };

            if (expiryDateTimeUtc > DateTime.UtcNow)
                return new AuthenticationDto { Errors = new[] { "This token hasn't expired jet" } };

            if (storedRefreshToken.Used)
                return new AuthenticationDto { Errors = new[] { "This refresh token has been used" }, CriticalError = true };

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                return new AuthenticationDto { Errors = new[] { "This refresh token has expired" }, CriticalError = true };

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (storedRefreshToken.JwtId != jti)
                return new AuthenticationDto { Errors = new[] { "This refresh token does not match this JWT" }, CriticalError = true };

            storedRefreshToken.Used = true;
            _context.RefreshTokens.Update(storedRefreshToken);
            await _context.SaveChangesAsync();

            var user = await _userManager.FindByIdAsync(validatedToken.Claims
                .Single(x => x.Type == "userId").Value);

            return await GenerateAuthenticationResultForUserAsync(user);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValidationParameters = _tokenValidationParameters.Clone();
                tokenValidationParameters.ValidateLifetime = false;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return validatedToken is JwtSecurityToken jwtSecurityToken &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                       StringComparison.InvariantCultureIgnoreCase);
        }

        private async Task<AuthenticationDto> GenerateAuthenticationResultForUserAsync(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role is null) continue;
                var roleClaims = await _roleManager.GetClaimsAsync(role);

                foreach (var roleClaim in roleClaims)
                {
                    if (claims.Contains(roleClaim))
                        continue;

                    claims.Add(roleClaim);
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthenticationDto
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }
    }
}
