using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Auth;

namespace Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationDto> RegisterAsync(string email, string password, string name);

        Task<AuthenticationDto> LoginAsync(string email, string password);

        Task<AuthenticationDto> RefreshTokenAsync(string token, string refreshToken);
    }
}
