using System;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Failed;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Success;
using BBIT.Domain.Entities.DTO.House;
using Interfaces.Flat;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Mappers.Flat;
using Services.StaticHelpers;

namespace BBIT.WEB.Service.Controllers.V1.Flat
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
            if (request is null)
                return BadRequest(new FailedFlatCreationResponse
                {
                    Status = false,
                    Errors = new[] { "Request should have a valid data." }
                });

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
                    Level = creationResult.Floor,
                    AmountOfRooms = creationResult.AmountOfRooms,
                    AmountOfResidents = creationResult.AmountOfTenants,
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
        /// <response code="200">Returns list of Flats</response>
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

        /// <summary>
        /// Update Flat endpoint. Returns updated Flat
        /// </summary>
        /// <response code="200">Returns Updated Flat</response>
        /// <response code="400">Failed request returns status and list of errors</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(SuccessUpdateFlatResponse), 200)]
        [ProducesResponseType(typeof(FailedUpdateFlatResponse), 400)]
        [HttpPut(ApiRoutes.FlatRoute.FlatV1)]
        public async Task<IActionResult> UpdateFlat([FromBody] UpdateFlatRequest request)
        {
            if (request is null)
                return BadRequest(new FailedUpdateFlatResponse
                {
                    Errors = new[] { "Request should have a valid data." },
                    Status = false
                });


            //Checking all props have values
            if (PropertyHelper.IsAnyPropIsNull(request))
                return BadRequest(
                    new FailedUpdateFlatResponse
                    {
                        Status = false,
                        Errors = new[] { "Some of properties are null." }
                    }
                );

            var updateRequestResult = await _flatService.UpdateFlatAsync(request.UpdateFlatRequestToUpdateFlatDto());

            if (!updateRequestResult.Status)
            {
                if (updateRequestResult.ServerError)
                    return StatusCode(500);

                if (updateRequestResult.ItemNotFound)
                    return BadRequest(new FailedUpdateFlatResponse
                    {
                        Errors = new[] { "Flat not found" },
                        Status = false
                    });

                return BadRequest(new FailedUpdateFlatResponse
                {
                    Errors = updateRequestResult.Errors,
                    Status = updateRequestResult.Status
                });
            }

            return Ok(new SuccessUpdateFlatResponse
            {
                Status = true,
                Flat = updateRequestResult.Flat
            });
        }

        /// <summary>
        /// Delete Flat endpoint. Deleting flat by provided id
        /// </summary>
        /// <response code="204">Returns empty body</response>
        /// <response code="400">Failed request returns status and list of errors</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Server error</response>
        [ProducesResponseType(typeof(FailedDeleteFlatResponse), 400)]
        [HttpDelete(ApiRoutes.FlatRoute.FlatByIdV1)]
        public async Task<IActionResult> DeleteFlat(string id)
        {
            var deleteRequestResult = await _flatService.DeleteFlatAsync(id);

            if (!deleteRequestResult.Status)
            {
                if (deleteRequestResult.ServerError)
                    return StatusCode(500);

                if (deleteRequestResult.Errors.Contains("Item not found."))
                    return NotFound(new FailedDeleteFlatResponse
                    {
                        Status = false,
                        Errors = new[] { "Flat not found." }
                    });

                return BadRequest(new FailedDeleteFlatResponse
                {
                    Status = deleteRequestResult.Status,
                    Errors = deleteRequestResult.Errors
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Flat tenants endpoint. Returns list of tenants in flat.
        /// </summary>
        /// <response code="200">Returns list of tenants in flat</response>
        /// <response code="400">Failed request returns status and list of errors</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(SuccessFlatTenantsResponse), 200)]
        [ProducesResponseType(typeof(FailedFlatTenantsResponse), 400)]
        [HttpGet(ApiRoutes.FlatRoute.FlatTenantsV1)]
        public IActionResult FlatTenants(string id)
        {
            var flatTenantsResult = _flatService.GetFlatTenants(id);

            if (!flatTenantsResult.Status)
            {
                if (flatTenantsResult.ServerError)
                    return StatusCode(500);

                if (flatTenantsResult.ItemNotFound)
                    return NotFound(new FailedFlatTenantsResponse
                    {
                        Status = false,
                        Errors = new[] { "House not found." }
                    });

                return BadRequest(new FailedFlatTenantsResponse
                {
                    Errors = flatTenantsResult.Errors,
                    Status = flatTenantsResult.Status
                });
            }

            return Ok(new SuccessFlatTenantsResponse
            {
                Status = flatTenantsResult.Status,
                Tenants = flatTenantsResult.Tenants
            });
        }
    }
}