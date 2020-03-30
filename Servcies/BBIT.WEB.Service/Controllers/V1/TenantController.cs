using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using Interfaces.Resident;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Mappers.Tenant;
using Services.StaticHelpers;

namespace BBIT.WEB.Service.Controllers.V1
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
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /With FlatId
        ///     {
        ///        FlatId = "4644e41b-c19e-4f24-96f3-013103030c5a",
        ///        Name = "Name",
        ///        Surname = "Surname",
        ///        PersonalCode = "12345",
        ///        DateOfBirth = DateTime.Today,
        ///        PhoneNumber = "+37112345678",
        ///        Email = "email@mail.com"
        ///     }
        ///
        ///     POST /WithOut FlatId
        ///     {
        ///        Name = "Name",
        ///        Surname = "Surname",
        ///        PersonalCode = "12345",
        ///        DateOfBirth = DateTime.Today,
        ///        PhoneNumber = "+37112345678",
        ///        Email = "email@mail.com"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Success-full creation returns created tenant</response>
        /// <response code="400">Failed creation returns status and list of errors</response>
        /// <response code="404">House or Flat not found</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessTenantCreationResponse), 201)]
        [ProducesResponseType(typeof(FailedTenantCreationResponse), 400)]
        [HttpPost(ApiRoutes.TenantRoute.TenantV1)]
        public async Task<IActionResult> CreateTenant([FromServices] IConfiguration configuration, [FromBody] CreateTenantRequest request)
        {
            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNullExceptFlatId(request))
                return BadRequest(
                    new FailedTenantCreationResponse
                    {
                        Status = false,
                        Errors = new[] { "Some of properties are null." }
                    }
                );

            var createTenantResult = await _tenantService.CreateTenantAsync(request.CreateTenantRequestToCreateTenantDto());

            if (!createTenantResult.Status)
            {
                if (createTenantResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedTenantCreationResponse
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

        //[HttpGet(ApiRoutes.TenantRoute.TenantV1)]
        //public IActionResult GetAllFlats()
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpGet(ApiRoutes.TenantRoute.TenantByIdV1)]
        //public IActionResult GetFlatById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpPut(ApiRoutes.TenantRoute.TenantV1)]
        //public IActionResult UpdateFlat()
        //{
        //    throw new NotImplementedException();
        //}


        //[HttpDelete(ApiRoutes.TenantRoute.TenantByIdV1)]
        //public IActionResult DeleteFlat()
        //{
        //    throw new NotImplementedException();
        //}
    }
}