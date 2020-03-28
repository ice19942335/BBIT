using System.Collections.Generic;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.DTO.House;
using Interfaces.House;
using Interfaces.Sql.House;

namespace Services.House
{
    public class HouseService : IHouseService
    {
        private readonly ISqlHouseService _sqlHouseService;
        private readonly BBITContext _dbContext;

        public HouseService(ISqlHouseService sqlHouseService, BBITContext dbContext)
        {
            _sqlHouseService = sqlHouseService;
            _dbContext = dbContext;
        }

        public async Task<CreateHouseDto> CreateHouseAsync(CreateHouseDto createHouseDto)
        {
            var creationResult = await _sqlHouseService.CreateHouse(createHouseDto);

            return creationResult;
        }

        public AllHousesDto GetAllHouses() => _sqlHouseService.GetAllHouses();
    }
}
