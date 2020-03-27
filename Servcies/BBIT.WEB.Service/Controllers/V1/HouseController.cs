using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BBIT.WEB.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BBIT.WEB.Service.Controllers.V1
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
    public class HouseController : Controller
    {
        [HttpPost(ApiRoutes.HouseRoute.HouseV1)]
        public IActionResult CreateHouse()
        {
            throw new NotImplementedException();
        }

        [HttpGet(ApiRoutes.HouseRoute.HouseV1)]
        public IActionResult GetAllHouses()
        {
            throw new NotImplementedException();
        }

        [HttpGet(ApiRoutes.HouseRoute.HouseV1)]
        public IActionResult GetHouseById(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPut(ApiRoutes.HouseRoute.HouseV1)]
        public IActionResult UpdateHouse()
        {
            throw new NotImplementedException();
        }


        [HttpDelete(ApiRoutes.HouseRoute.HouseV1)]
        public IActionResult DeleteHouse()
        {
            throw new NotImplementedException();
        }
    }
}