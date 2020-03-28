using System;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using BBIT.WEB.Service.Contracts;
using BBIT.WEB.Service.Contracts.V1.Requests.House;
using BBIT.WEB.Service.Contracts.V1.Responses.House;
using Interfaces.House;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        /// <response code="200">Success-full creation returns created item</response>
        /// <response code="400">Failed creation returns status and list of errors</response>
        [ProducesResponseType(typeof(SuccessHouseCreationResponse), 200)]
        [ProducesResponseType(typeof(FailedHouseCreationResponse), 400)]
        [HttpPost(ApiRoutes.HouseRoute.HouseV1)]
        public async Task<IActionResult> CreateHouse([FromBody] CreateHouseRequest request)
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
                return BadRequest(new FailedHouseCreationResponse
                {
                    Status = creationResult.Status,
                    Errors = creationResult.Errors
                });

            return Ok(new SuccessHouseCreationResponse
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
        [AllowAnonymous]
        [HttpGet(ApiRoutes.HouseRoute.HouseV1)]
        public IActionResult GetAllHouses()
        {
            var requestResult = _houseService.GetAllHouses();

            if (!requestResult.Status)
                return BadRequest(new FailedAllHousesResponse
                {
                    Status = requestResult.Status,
                    Errors = requestResult.Errors
                });

            return Ok(new SuccessAllHousesResponse
            {
                Status = requestResult.Status,
                Houses = requestResult.Houses
            });
        }

        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.HouseRoute.HouseV1)]
        //public IActionResult GetHouseById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpPut(ApiRoutes.HouseRoute.HouseV1)]
        //public IActionResult UpdateHouse()
        //{
        //    throw new NotImplementedException();
        //}


        //[HttpDelete(ApiRoutes.HouseRoute.HouseV1)]
        //public IActionResult DeleteHouse()
        //{
        //    throw new NotImplementedException();
        //}
    }
}