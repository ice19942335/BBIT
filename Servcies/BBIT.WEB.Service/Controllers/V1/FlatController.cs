using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using BBIT.Domain.Entities.DTO.House;
using Interfaces.Flat;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Mappers.Flat;
using Services.StaticHelpers;

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
        public async Task<IActionResult> CreateFlat([FromServices] IConfiguration configuration, [FromBody] CreateFlatRequest request)
        {
            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNull(request))
                return BadRequest(
                    new FailedFlatCreationResponse
                    {
                        Status = false,
                        Errors = new[] { "Some of properties are null." }
                    }
                );

            var creationResult = await _flatService.CreateFlatAsync(request.CreateFlatRequestToCreateFlatDto());

            if (!creationResult.Status)
            {
                if (creationResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedFlatCreationResponse
                {
                    Errors = creationResult.Errors,
                    Status = creationResult.Status
                });
            }

            string itemUrl =
                $"{configuration["ApplicationHostAddress"]}/{ApiRoutes.FlatRoute.FlatV1}/{creationResult.Id}";

            return Created(
                new Uri(itemUrl),
                new SuccessFlatCreationResponse
                {
                    Id = creationResult.Id,
                    FlatNumber = creationResult.FlatNumber,
                    Floor = creationResult.Floor,
                    AmountOfRooms = creationResult.AmountOfRooms,
                    AmountOfResidents = creationResult.AmountOfResidents,
                    TotalArea = creationResult.TotalArea,
                    HouseRoom = creationResult.HouseRoom,
                    House = new HouseDto
                    {
                        Id = creationResult.House.Id,
                        HouseNumber = creationResult.House.HouseNumber,
                        StreetName = creationResult.House.StreetName,
                        City = creationResult.House.City,
                        Country = creationResult.House.Country,
                        PostCode = creationResult.House.PostCode
                    }
                });
        }

        //[HttpGet(ApiRoutes.FlatRoute.FlatV1)]
        //public IActionResult GetAllFlats()
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpGet(ApiRoutes.FlatRoute.FlatByIdV1)]
        //public IActionResult GetFlatById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpPut(ApiRoutes.FlatRoute.FlatV1)]
        //public IActionResult UpdateFlat()
        //{
        //    throw new NotImplementedException();
        //}


        //[HttpDelete(ApiRoutes.FlatRoute.FlatByIdV1)]
        //public IActionResult DeleteFlat()
        //{
        //    throw new NotImplementedException();
        //}
    }
}