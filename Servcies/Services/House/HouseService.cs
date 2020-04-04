using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.House;
using Interfaces.House;
using Interfaces.Sql.House;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Mappers.Flat;

namespace Services.House
{
    public class HouseService : IHouseService
    {
        private readonly ISqlHouseService _sqlHouseService;
        private readonly BBITContext _dbContext;
        private readonly ILogger<HouseService> _logger;

        public HouseService(ISqlHouseService sqlHouseService, BBITContext dbContext, ILogger<HouseService> logger)
        {
            _sqlHouseService = sqlHouseService;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CreateHouseDto> CreateHouseAsync(CreateHouseDto createHouseDto) => await _sqlHouseService.CreateHouseAsync(createHouseDto);

        public AllHousesDto GetAllHouses() => _sqlHouseService.GetAllHouses();

        public HouseByIdDto GetHouseById(string id) => _sqlHouseService.GetHouseById(id);

        public async Task<UpdateHouseDto> UpdateHouseAsync(UpdateHouseDto updateHouseDto) => await _sqlHouseService.UpdateHouse(updateHouseDto);

        public async Task<DeleteHouseDto> DeleteHouseAsync(string id) => await _sqlHouseService.DeleteHouseAsync(id);

        public AllFlatsDto GetAllFlatsInHouseByHouseId(string id)
        {
            try
            {
                var house = _dbContext.Houses.FirstOrDefault(x => x.Id == Guid.Parse(id));

                if (house is null)
                    return new AllFlatsDto
                    {
                        Errors = new[] { "House not found." },
                        ItemNotFound = true
                    };

                var flats = _dbContext.Flats
                    .Include(x => x.House)
                    .Where(x => x.House.Id == Guid.Parse(id))
                    .ToList()
                    .OrderBy(x => x.FlatNumber);

                return new AllFlatsDto
                {
                    Status = true,
                    Flats = flats.Select(x => x.FlatToFlatDto())
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on deleting house from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new AllFlatsDto
                {
                    Errors = new[] { "Error on fetching data from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }
    }
}
