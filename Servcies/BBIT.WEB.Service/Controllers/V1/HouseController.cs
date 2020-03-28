using BBIT.WEB.Service.Contracts;
using BBIT.WEB.Service.Contracts.V1.Requests.House;
using BBIT.WEB.Service.Contracts.V1.Responses.House;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services.StaticHelpers;

namespace BBIT.WEB.Service.Controllers.V1
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
    public class HouseController : Controller
    {
        /// <summary>
        /// House creation endpoint. Creating new House in DB and returning created item
        /// </summary>
        /// <response code="200">Success-full creation returning created item</response>
        /// <response code="400">Failed creation returns status and list of errors</response>
        [ProducesResponseType(typeof(SuccessHouseCreationResponse), 200)]
        [ProducesResponseType(typeof(FailedHouseCreationResponse), 400)]
        [HttpPost(ApiRoutes.HouseRoute.HouseV1)]
        public IActionResult CreateHouse([FromBody] CreateHouseRequest request)
        {
            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNull(request))
                return BadRequest(
                    new FailedHouseCreationResponse
                    {
                        Status = false,
                        Errors = new[] { "Some of properties are null" }
                    }
                );

            return Ok();
        }

        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.HouseRoute.HouseV1)]
        //public IActionResult GetAllHouses()
        //{
        //    throw new NotImplementedException();
        //}

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