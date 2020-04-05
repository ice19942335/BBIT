using System;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant.Failed;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant.Success;
using BBIT.Domain.Entities.DTO.Tenant;
using Interfaces.Tenant;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Mappers.Tenant;
using Services.StaticHelpers;

namespace BBIT.WEB.Service.Controllers.V1.Tenant
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
    public class TenantController : Controller
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        /// <summary>
        /// Tenant creation endpoint. Creating new Tenant in DB and returns created item
        /// </summary>
        /// <response code="201">Success-full creation returns created tenant</response>
        /// <response code="400">Failed creation returns status and list of errors</response>
        /// <response code="404">House or Flat not found</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(SuccessTenantCreationResponse), 201)]
        [ProducesResponseType(typeof(FailedTenantResponse), 400)]
        [HttpPost(ApiRoutes.TenantRoute.TenantV1)]
        public async Task<IActionResult> CreateTenant([FromServices] IConfiguration configuration, [FromBody] CreateTenantRequest request)
        {
            if (request is null)
                return BadRequest(new FailedTenantResponse
                {
                    Status = false,
                    Errors = new[] { "Request should have a valid data." }
                });

            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNull(request))
                return BadRequest(
                    new FailedTenantResponse
                    {
                        Status = false,
                        Errors = new[] { $"Tenant properties can not be null." }
                    }
                );

            var createTenantResult = await _tenantService.CreateTenantAsync(request.CreateTenantRequestToCreateTenantDto());

            if (!createTenantResult.Status)
            {
                if (createTenantResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedTenantResponse
                {
                    Status = createTenantResult.Status,
                    Errors = createTenantResult.Errors
                });
            }

            string itemUrl =
                $"{configuration["ApplicationHostAddress"]}/{ApiRoutes.TenantRoute.TenantV1}/{createTenantResult.Tenant.Id}";

            return Created(
                new Uri(itemUrl),
                new SuccessTenantCreationResponse
                {
                    Id = createTenantResult.Tenant.Id,
                    Name = createTenantResult.Tenant.Name,
                    Surname = createTenantResult.Tenant.Surname,
                    PersonalCode = createTenantResult.Tenant.PersonalCode,
                    DateOfBirth = createTenantResult.Tenant.DateOfBirth,
                    PhoneNumber = createTenantResult.Tenant.PhoneNumber,
                    Email = createTenantResult.Tenant.Email,
                    Flat = createTenantResult.Tenant.Flat
                });
        }

        /// <summary>
        /// Get all tenants endpoint. Returns list of tenants
        /// </summary>
        /// <response code="200">Returns list of tenants</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessAllTenantsResponse), 200)]
        [ProducesResponseType(typeof(FailedTenantResponse), 400)]
        [HttpGet(ApiRoutes.TenantRoute.TenantV1)]
        public IActionResult GetAllTenants()
        {
            var getAllFlatsResult = _tenantService.GetAllTenants();

            if (!getAllFlatsResult.Status)
            {
                if (getAllFlatsResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedTenantResponse
                {
                    Status = getAllFlatsResult.Status,
                    Errors = getAllFlatsResult.Errors
                });
            }

            return Ok(new SuccessAllTenantsResponse
            {
                Status = getAllFlatsResult.Status,
                Tenants = getAllFlatsResult.Tenants
            });
        }

        /// <summary>
        /// Get Tenant by Id endpoint. Returns Tenant by provided Id
        /// </summary>
        /// <response code="200">Returns Tenants</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="404">Tenant not found</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessTenantByIdResponse), 200)]
        [ProducesResponseType(typeof(FailedTenantResponse), 400)]
        [HttpGet(ApiRoutes.TenantRoute.TenantByIdV1)]
        public IActionResult GetTenantById(string id)
        {
            var tenantByIdResult = _tenantService.GetTenantById(id);

            if (!tenantByIdResult.Status)
            {
                if (tenantByIdResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedTenantResponse
                {
                    Status = tenantByIdResult.Status,
                    Errors = tenantByIdResult.Errors
                });
            }

            return Ok(new SuccessTenantByIdResponse
            {
                Id = tenantByIdResult.Tenant.Id,
                Name = tenantByIdResult.Tenant.Name,
                Surname = tenantByIdResult.Tenant.Name,
                PersonalCode = tenantByIdResult.Tenant.Name,
                DateOfBirth = tenantByIdResult.Tenant.DateOfBirth,
                PhoneNumber = tenantByIdResult.Tenant.PhoneNumber,
                Email = tenantByIdResult.Tenant.Email,
                Flat = tenantByIdResult.Tenant.Flat
            });
        }

        /// <summary>
        /// Update Tenant endpoint. Returns updated Tenant
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /With NewFlatId
        ///     {
        ///       "newFlatId": "4644e41b-c19e-4f24-96f3-013103030c5a",
        ///       "id": "486051a1-8867-47cd-b4c0-44c5a62f0e99"
        ///       "name": "Name",
        ///       "surname": "Surname",
        ///       "personalCode": "12345",
        ///       "dateOfBirth": "2020-03-30T00:00:00+01:00",
        ///       "phoneNumber": "+37112345678",
        ///       "email": "email@mail.com"
        ///     }
        ///
        ///     PUT /Without NewFlatId
        ///     {
        ///       "newFlatId": null,
        ///       "id": "486051a1-8867-47cd-b4c0-44c5a62f0e99"
        ///       "name": "Name",
        ///       "surname": "Surname",
        ///       "personalCode": "12345",
        ///       "dateOfBirth": "2020-03-30T00:00:00+01:00",
        ///       "phoneNumber": "+37112345678",
        ///       "email": "email@mail.com"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Returns updated Tenants</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="404">Tenant not found</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(SuccessUpdateTenantResponse), 200)]
        [ProducesResponseType(typeof(FailedTenantResponse), 400)]
        [HttpPut(ApiRoutes.TenantRoute.TenantV1)]
        public async Task<IActionResult> UpdateTenant([FromBody] UpdateTenantRequest request)
        {
            if (request is null)
                return BadRequest(new FailedTenantResponse
                {
                    Status = false,
                    Errors = new[] { "Request should have a valid data." }
                });

            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNullExceptFlatId(request))
                return BadRequest(
                    new FailedTenantResponse
                    {
                        Status = false,
                        Errors = new[] { $"Tenant properties can not be null." }
                    }
                );

            if (!ModelState.IsValid)
            {
                return BadRequest(new FailedTenantResponse
                {
                    Status = false,
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            
            var updateTenantResult = await _tenantService.UpdateTenantAsync(request.UpdateTenantRequestToUpdateTenantDto());

            if (!updateTenantResult.Status)
            {
                if (updateTenantResult.ServerError)
                    return StatusCode(500);

                if (updateTenantResult.Errors.Contains("Tenant not found."))
                    return NotFound("Tenant not found.");

                if (updateTenantResult.Errors.Any(x => x.Contains($"Flat with Id: '{request.NewFlatId}' not found.")))
                    return NotFound($"Flat with Id: '{request.NewFlatId}' not found.");

                return BadRequest(new FailedTenantResponse
                {
                    Status = updateTenantResult.Status,
                    Errors = updateTenantResult.Errors
                });
            }

            return Ok(new SuccessUpdateTenantResponse
            {
                Status = updateTenantResult.Status,
                Tenant = new TenantDto
                {
                    Id = updateTenantResult.Tenant.Id,
                    Name = updateTenantResult.Tenant.Name,
                    Surname = updateTenantResult.Tenant.Surname,
                    PersonalCode = updateTenantResult.Tenant.PersonalCode,
                    DateOfBirth = updateTenantResult.Tenant.DateOfBirth,
                    PhoneNumber = updateTenantResult.Tenant.PhoneNumber,
                    Email = updateTenantResult.Tenant.Email,
                    Flat = updateTenantResult.Tenant.Flat
                }
            });
        }

        /// <summary>
        /// Delete Tenant endpoint. Deleting Tenant by provided Id
        /// </summary>
        /// <response code="204">Returns no content</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="404">Tenant not found</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(FailedTenantResponse), 400)]
        [HttpDelete(ApiRoutes.TenantRoute.TenantByIdV1)]
        public async Task<IActionResult> DeleteTenant(string id)
        {
            var deleteTenantResult = await _tenantService.DeleteTenantAsync(id);

            if (!deleteTenantResult.Status)
            {
                if (deleteTenantResult.ServerError)
                    return StatusCode(500);

                if (deleteTenantResult.Errors.Contains($"Tenant with Id: '{id}' not found."))
                    return NotFound($"Tenant with Id: '{id}' not found.");

                return BadRequest(new FailedTenantResponse
                {
                    Status = deleteTenantResult.Status,
                    Errors = deleteTenantResult.Errors
                });
            }

            return NoContent();
        }
    }
}