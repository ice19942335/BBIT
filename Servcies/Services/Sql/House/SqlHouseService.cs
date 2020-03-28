using System;
using System.Linq;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.DTO.House;
using Interfaces.Sql.House;
using Microsoft.Extensions.Logging;
using Services.Mappers.House;

namespace Services.Sql.House
{
    public class SqlHouseService : ISqlHouseService
    {
        private readonly BBITContext _dbContext;
        private readonly ILogger<SqlHouseService> _logger;

        public SqlHouseService(BBITContext dbContext, ILogger<SqlHouseService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CreateHouseDto> CreateHouse(CreateHouseDto createHouseDto)
        {
            Guid id;
            do { id = Guid.NewGuid(); } while (_dbContext.Houses.FirstOrDefault(x => x.Id == id) != null);

            BBIT.Domain.Entities.House.House newHouse = createHouseDto.CreateDtoToHouse();
            newHouse.Id = id;

            await _dbContext.Houses.AddAsync(newHouse);

            try
            {
                await _dbContext.SaveChangesAsync();

                return newHouse.HouseToCreateHouseDto();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on adding new house into database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new CreateHouseDto
                {
                    Errors = new[] { "Error on adding new house into database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public AllHousesDto GetAllHouses()
        {
            try
            {
                return new AllHousesDto
                {
                    Houses = _dbContext.Houses.Select(x => x.HouseToHouseDto()),
                    Status = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on fetch data from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new AllHousesDto
                {
                    Errors = new[] { "Error on fetch data from database" },
                    ServerError = true,
                    Status = false
                };
            }
        }
    }
}
