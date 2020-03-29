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
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        /// <summary>
        /// All Flats endpoint. Returns list of Flats
        /// </summary>
        /// <response code="200">Returns Flats list</response>
        /// <response code="400">Failed request returns status and list of errors</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessAllFlatResponse), 200)]
        [ProducesResponseType(typeof(FailedAllFlatResponse), 400)]
        [HttpGet(ApiRoutes.FlatRoute.FlatV1)]
        public IActionResult GetAllFlats()
        {
            var allFlatsResult = _flatService.GetAllFlats();

            if (!allFlatsResult.Status)
            {
                if (allFlatsResult.ServerError)
                    return StatusCode(500);

                return BadRequest(new FailedAllFlatResponse
                {
                    Errors = allFlatsResult.Errors,
                    Status = allFlatsResult.Status
                });
            }

            return Ok(new SuccessAllFlatResponse
            {
                Flats = allFlatsResult.Flats,
                Status = allFlatsResult.Status
            });
        }

        /// <summary>
        /// Flat by id endpoint. Returns flat by provided id
        /// </summary>
        /// <response code="200">Returns Flat</response>
        /// <response code="400">Failed request returns status and list of errors</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessFlatByIdResponse), 200)]
        [ProducesResponseType(typeof(FailedFlatByIdResponse), 400)]
        [HttpGet(ApiRoutes.FlatRoute.FlatByIdV1)]
        public IActionResult GetFlatById(string id)
        {
            var requestResult = _flatService.GetFlatById(id);

            if (!requestResult.Status)
            {
                if (requestResult.ServerError)
                    return StatusCode(500);

                if (requestResult.Errors.Contains("Flat not found"))
                    return NotFound("Flat not found");

                return BadRequest(new FailedFlatByIdResponse
                {
                    Errors = requestResult.Errors,
                    Status = requestResult.Status
                });
            }

            return Ok(new SuccessFlatByIdResponse
            {
                Flat = requestResult.Flat,
                Status = requestResult.Status
            });
        }

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