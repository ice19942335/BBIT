﻿using System;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.House;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Success;
using Interfaces.House;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Mappers.House;
using Services.StaticHelpers;

namespace BBIT.WEB.Service.Controllers.V1.House
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
    public class HouseController : Controller
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        /// <summary>
        /// House creation endpoint. Creating new House in DB and returns created item
        /// </summary>
        /// <response code="201">Success-full creation returns created item</response>
        /// <response code="400">Failed creation returns status and list of errors</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(SuccessHouseCreationResponse), 201)]
        [ProducesResponseType(typeof(FailedHouseResponse), 400)]
        [HttpPost(ApiRoutes.HouseRoute.HouseV1)]
        public async Task<IActionResult> CreateHouse([FromServices] IConfiguration configuration, [FromBody] CreateHouseRequest request)
        {
            if (request is null)
                return BadRequest(new FailedHouseResponse
                {
                    Status = false,
                    Errors = new[] { "Request should have a valid data." }
                });

            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNull(request))
                return BadRequest(
                    new FailedHouseResponse
                    {
                        Status = false,
                        Errors = new[] { "House properties can not be null." }
                    }
                );

            var creationResult = await _houseService.CreateHouseAsync(request.CreateHouseRequestToCreateHouseDto());

            if (!creationResult.Status)
            {
                if (creationResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedHouseResponse
                {
                    Status = creationResult.Status,
                    Errors = creationResult.Errors
                });
            }

            string itemUrl =
                $"{configuration["ApplicationHostAddress"]}/{ApiRoutes.HouseRoute.HouseV1}/{creationResult.House.Id}";

            return Created(
                new Uri(itemUrl),
                new SuccessHouseCreationResponse
                {
                    Id = creationResult.House.Id,
                    HouseNumber = creationResult.House.HouseNumber,
                    StreetName = creationResult.House.StreetName,
                    City = creationResult.House.City,
                    Country = creationResult.House.Country,
                    PostCode = creationResult.House.PostCode
                });
        }

        /// <summary>
        /// House list endpoint, returns all houses
        /// </summary>
        /// <response code="200">Returns all houses</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [HttpGet(ApiRoutes.HouseRoute.HouseV1)]
        [ProducesResponseType(typeof(SuccessAllHousesResponse), 200)]
        [ProducesResponseType(typeof(FailedHouseResponse), 400)]
        public IActionResult GetAllHouses()
        {
            var requestResult = _houseService.GetAllHouses();

            if (!requestResult.Status)
            {
                if (requestResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedHouseResponse
                {
                    Status = requestResult.Status,
                    Errors = requestResult.Errors
                });
            }

            return Ok(new SuccessAllHousesResponse
            {
                Status = requestResult.Status,
                Houses = requestResult.Houses
            });
        }

        /// <summary>
        /// House by id endpoint, returns house by provided id
        /// </summary>
        /// <response code="200">Returns house by provided id</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [HttpGet(ApiRoutes.HouseRoute.HouseByIdV1)]
        [ProducesResponseType(typeof(SuccessHouseByIdResponse), 200)]
        [ProducesResponseType(typeof(FailedHouseResponse), 400)]
        public IActionResult GetHouseById(string id)
        {
            var requestResult = _houseService.GetHouseById(id);

            if (!requestResult.Status)
            {
                if (requestResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedHouseResponse
                {
                    Errors = requestResult.Errors,
                    Status = requestResult.Status
                });
            }

            if (requestResult.House is null)
                return NotFound("Item not found.");

            return Ok(new SuccessHouseByIdResponse
            {
                House = requestResult.House,
                Status = requestResult.Status
            });
        }

        /// <summary>
        /// Update house endpoint, returns updated item
        /// </summary>
        /// <response code="200">Returns updated item</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Server error</response>
        [HttpPut(ApiRoutes.HouseRoute.HouseV1)]
        [ProducesResponseType(typeof(SuccessUpdateHouseResponse), 200)]
        [ProducesResponseType(typeof(FailedHouseResponse), 400)]
        public async Task<IActionResult> UpdateHouse([FromBody] UpdateHouseRequest request)
        {
            if (request is null)
                return BadRequest(new FailedHouseResponse
                {
                    Errors = new []{ "Request should have a valid data." },
                    Status = false
                });

            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNull(request))
                return BadRequest(
                    new FailedHouseResponse
                    {
                        Status = false,
                        Errors = new[] { "House properties can not be null." }
                    }
                );

            var updateHouseResponse = await _houseService.UpdateHouseAsync(request.UpdateHouseRequestToUpdateHouseDto());

            if (!updateHouseResponse.Status)
            {
                if (updateHouseResponse.ServerError)
                    return StatusCode(500);

                if (updateHouseResponse.Errors.Contains("Item not found"))
                    return NotFound("Item not found");

                return BadRequest(new FailedHouseResponse
                {
                    Errors = updateHouseResponse.Errors,
                    Status = updateHouseResponse.Status
                });
            }

            return Ok(new SuccessUpdateHouseResponse
            {
                House = updateHouseResponse.UpdateHouseDtoToHouseDto(),
                Status = updateHouseResponse.Status
            });
        }

        /// <summary>
        /// Delete house endpoint, deleting house from database
        /// </summary>
        /// <response code="204">Successfully deleted</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete(ApiRoutes.HouseRoute.HouseByIdV1)]
        [ProducesResponseType(typeof(FailedHouseResponse), 400)]
        public async Task<IActionResult> DeleteHouse(string id)
        {
            var deletionResult = await _houseService.DeleteHouseAsync(id);

            if (!deletionResult.Status)
            {
                if (deletionResult.ServerError)
                    return StatusCode(500);

                if (deletionResult.Errors.Contains("Item not found."))
                    return NotFound("Item not found");

                return BadRequest(new FailedHouseResponse
                {
                    Status = false,
                    Errors = deletionResult.Errors
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Flats in house by house Id. Returns list of Flats in particular house.
        /// </summary>
        /// <response code="200">Returns list of Flats in particular house</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="404">House not found.</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessHouseFlatsResponse), 200)]
        [ProducesResponseType(typeof(FailedHouseResponse), 400)]
        [HttpGet(ApiRoutes.HouseRoute.FlatsInHouseById)]
        public IActionResult GetHouseFlats(string id)
        {
            var flatsInHouseResult = _houseService.GetHouseFlats(id);

            if (!flatsInHouseResult.Status)
            {
                if (flatsInHouseResult.ServerError)
                    return StatusCode(500);

                if (flatsInHouseResult.ItemNotFound)
                    return NotFound("House not found.");

                return BadRequest(new FailedHouseResponse
                {
                    Errors = flatsInHouseResult.Errors,
                    Status = flatsInHouseResult.Status
                });
            }

            return Ok(new SuccessHouseFlatsResponse
            {
                Status = flatsInHouseResult.Status,
                Flats = flatsInHouseResult.Flats
            });
        }
    }
}