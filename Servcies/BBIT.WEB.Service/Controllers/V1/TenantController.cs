﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using BBIT.WEB.Service.SwaggerExamples.Responses.Tenant;
using Interfaces.Tenant;
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
        ///         "flatId": "4644e41b-c19e-4f24-96f3-013103030c5a",
        ///         "name": "Name",
        ///         "surname": "Surname",
        ///         "personalCode": "12345",
        ///         "dateOfBirth": "2020-03-30T00:00:00+01:00",
        ///         "phoneNumber": "+37112345678",
        ///         "email": "email@mail.com"
        ///     }
        ///
        ///     POST /WithOut FlatId
        ///     {
        ///         "flatId": null,
        ///         "name": "Name",
        ///         "surname": "Surname",
        ///         "personalCode": "12345",
        ///         "dateOfBirth": "2020-03-30T00:00:00+01:00",
        ///         "phoneNumber": "+37112345678",
        ///         "email": "email@mail.com"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Success-full creation returns created tenant</response>
        /// <response code="400">Failed creation returns status and list of errors</response>
        /// <response code="404">House or Flat not found</response>
        /// <response code="500">Server error</response>
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
                        Errors = new[] { $"Some of properties except {nameof(CreateTenantRequest.FlatId)} are null." }
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

        /// <summary>
        /// Get all tenants endpoint. Returns list of tenants
        /// </summary>
        /// <response code="200">Returns list of tenants</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessAllTenantsResponse), 200)]
        [ProducesResponseType(typeof(FailedAllTenantsResponse), 400)]
        [HttpGet(ApiRoutes.TenantRoute.TenantV1)]
        public IActionResult GetAllTenants()
        {
            var getAllFlatsResult = _tenantService.GetAllTenants();

            if (!getAllFlatsResult.Status)
            {
                if (getAllFlatsResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedAllTenantsResponse
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
        [ProducesResponseType(typeof(SuccessTenantByIdResponseExample), 200)]
        [ProducesResponseType(typeof(FailedTenantByIdResponseExample), 400)]
        [HttpGet(ApiRoutes.TenantRoute.TenantByIdV1)]
        public IActionResult GetTenantById(string id)
        {
            var tenantByIdResult = _tenantService.GetTenantById(id);

            if (!tenantByIdResult.Status)
            {
                if (tenantByIdResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedTenantByIdResponse
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

        //[HttpPut(ApiRoutes.TenantRoute.TenantV1)]
        //public IActionResult UpdateTenant()
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpDelete(ApiRoutes.TenantRoute.TenantByIdV1)]
        //public IActionResult DeleteTenant()
        //{
        //    throw new NotImplementedException();
        //}
    }
}