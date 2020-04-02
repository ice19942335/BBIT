using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.HouseExtended;
using Interfaces.House;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BBIT.WEB.Service.Controllers.V1.House
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
    public class HouseExtendedController : Controller
    {
        private readonly IHouseService _houseService;

        public HouseExtendedController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        /// <summary>
        /// Flats in house by house Id. Returns list of Flats in particular house.
        /// </summary>
        /// <response code="200">Returns list of Flats in particular house</response>
        /// <response code="400">Returns status and list of errors</response>
        /// <response code="404">House not found.</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessAllFlatsInHouseByHouseIdResponse), 200)]
        [ProducesResponseType(typeof(FailedAllFlatsInHouseByHouseIdResponse), 400)]
        [HttpGet(ApiRoutes.HouseRoute.FlatsInHouseById)]
        public IActionResult GetAllFlatsInHouseByHouseId(string id)
        {
            var flatsInHouseResult = _houseService.GetAllFlatsInHouseByHouseId(id);

            if (!flatsInHouseResult.Status)
            {
                if (flatsInHouseResult.ServerError)
                    return StatusCode(500);

                if (flatsInHouseResult.ItemNotFound)
                    return NotFound("House not found.");

                return BadRequest(new FailedAllFlatsInHouseByHouseIdResponse
                {
                    Errors = flatsInHouseResult.Errors,
                    Status = flatsInHouseResult.Status
                });
            }

            return Ok(new SuccessAllFlatsInHouseByHouseIdResponse
            {
                Status = flatsInHouseResult.Status,
                Flats = flatsInHouseResult.Flats
            });
        }
    }
}