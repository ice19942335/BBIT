using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BBIT.WEB.Service.Controllers.V1
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
    public class ResidentController : Controller
    {
        [HttpPost(ApiRoutes.ResidentRoute.ResidentV1)]
        public IActionResult CreateFlat()
        {
            throw new NotImplementedException();
        }

        [HttpGet(ApiRoutes.ResidentRoute.ResidentV1)]
        public IActionResult GetAllFlats()
        {
            throw new NotImplementedException();
        }

        [HttpGet(ApiRoutes.ResidentRoute.ResidentByIdV1)]
        public IActionResult GetFlatById(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPut(ApiRoutes.ResidentRoute.ResidentV1)]
        public IActionResult UpdateFlat()
        {
            throw new NotImplementedException();
        }


        [HttpDelete(ApiRoutes.ResidentRoute.ResidentByIdV1)]
        public IActionResult DeleteFlat()
        {
            throw new NotImplementedException();
        }
    }
}