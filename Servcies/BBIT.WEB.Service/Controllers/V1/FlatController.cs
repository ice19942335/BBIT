using System;
using System.Collections.Generic;
using System.Linq;
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
    public class FlatController : Controller
    {
        [HttpPost(ApiRoutes.FlatRoute.FlatV1)]
        public IActionResult CreateFlat()
        {
            throw new NotImplementedException();
        }

        [HttpGet(ApiRoutes.FlatRoute.FlatV1)]
        public IActionResult GetAllFlats()
        {
            throw new NotImplementedException();
        }

        [HttpGet(ApiRoutes.FlatRoute.FlatV1)]
        public IActionResult GetFlatById(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPut(ApiRoutes.FlatRoute.FlatV1)]
        public IActionResult UpdateFlat()
        {
            throw new NotImplementedException();
        }


        [HttpDelete(ApiRoutes.FlatRoute.FlatV1)]
        public IActionResult DeleteFlat()
        {
            throw new NotImplementedException();
        }
    }
}