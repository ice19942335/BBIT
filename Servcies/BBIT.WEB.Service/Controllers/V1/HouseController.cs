using System;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.House;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using BBIT.Domain.Entities.DTO.House;
using Interfaces.House;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Mappers.House;
using Services.StaticHelpers;

namespace BBIT.WEB.Service.Controllers.V1
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
        [ProducesResponseType(typeof(FailedHouseCreationResponse), 400)]
        [HttpPost(ApiRoutes.HouseRoute.HouseV1)]
        public async Task<IActionResult> CreateHouse([FromServices] IConfiguration configuration, [FromBody] CreateHouseRequest request)
        {
            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNull(request))
                return BadRequest(
                    new FailedHouseCreationResponse
                    {
                        Status = false,
                        Errors = new[] { "Some of properties are null." }
                    }
                );

            var creationResult = await _houseService.CreateHouseAsync(request.CreateHouseRequestToCreateHouseDto());

            if (!creationResult.Status)
            {
                if (creationResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedHouseCreationResponse
                {
                    Status = creationResult.Status,
                    Errors = creationResult.Errors
                });
            }

            string itemUrl =
                $"{configuration["ApplicationHostAddress"]}/{ApiRoutes.HouseRoute.HouseV1}/{creationResult.Id}";

            return Created(
                new Uri(itemUrl),
                new SuccessHouseCreationResponse
                {
                    Id = creationResult.Id,
                    HouseNumber = creationResult.HouseNumber,
                    StreetName = creationResult.StreetName,
                    City = creationResult.City,
                    Country = creationResult.Country,
                    PostCode = creationResult.PostCode
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
        [ProducesResponseType(typeof(FailedAllHousesResponse), 400)]
        public IActionResult GetAllHouses()
        {
            var requestResult = _houseService.GetAllHouses();

            if (!requestResult.Status)
            {
                if (requestResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedAllHousesResponse
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
        [ProducesResponseType(typeof(FailedHouseByIdResponse), 400)]
        public IActionResult GetHouseById(string id)
        {
            var requestResult = _houseService.GetHouseById(id);

            if (!requestResult.Status)
            {
                if (requestResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedHouseByIdResponse
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
        /// <response code="500">Server error</response>
        [HttpPut(ApiRoutes.HouseRoute.HouseV1)]
        [ProducesResponseType(typeof(SuccessUpdateHouseResponse), 200)]
        [ProducesResponseType(typeof(FailedUpdateHouseResponse), 400)]
        public async Task<IActionResult> UpdateHouse([FromBody] UpdateHouseRequest request)
        {
            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNull(request))
                return BadRequest(
                    new FailedHouseCreationResponse
                    {
                        Status = false,
                        Errors = new[] { "Some of properties are null." }
                    }
                );

            var updateHouseResponse = await _houseService.UpdateHouseAsync(request.UpdateHouseRequestToUpdateHouseDto());

            if (!updateHouseResponse.Status)
            {
                if (updateHouseResponse.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedUpdateHouseResponse
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


        //[HttpDelete(ApiRoutes.HouseRoute.HouseV1)]
        //public IActionResult DeleteHouse()
        //{
        //    throw new NotImplementedException();
        //}
    }
}