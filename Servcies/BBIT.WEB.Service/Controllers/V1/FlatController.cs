using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using Interfaces.Flat;
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
        private readonly IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        /// <summary>
        /// Flat creation endpoint. Creating new Flat in DB and returns created item
        /// </summary>
        /// <response code="201">Success-full creation returns created item</response>
        /// <response code="400">Failed creation returns status and list of errors</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(SuccessFlatCreationResponse), 201)]
        [ProducesResponseType(typeof(FailedFlatCreationResponse), 400)]
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

        [HttpGet(ApiRoutes.FlatRoute.FlatByIdV1)]
        public IActionResult GetFlatById(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPut(ApiRoutes.FlatRoute.FlatV1)]
        public IActionResult UpdateFlat()
        {
            throw new NotImplementedException();
        }


        [HttpDelete(ApiRoutes.FlatRoute.FlatByIdV1)]
        public IActionResult DeleteFlat()
        {
            throw new NotImplementedException();
        }
    }
}