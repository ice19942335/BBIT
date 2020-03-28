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

        public HouseService(ISqlHouseService sqlHouseService, BBITContext dbContext)
        {
            _sqlHouseService = sqlHouseService;
        }

        public async Task<CreateHouseDto> CreateHouseAsync(CreateHouseDto createHouseDto) => await _sqlHouseService.CreateHouse(createHouseDto);

        public AllHousesDto GetAllHouses() => _sqlHouseService.GetAllHouses();

        public HouseByIdDto GetHouseById(string id) => _sqlHouseService.GetHouseById(id);

        public async Task<UpdateHouseDto> UpdateHouseAsync(UpdateHouseDto updateHouseDto) => await _sqlHouseService.UpdateHouse(updateHouseDto);

        public Task<DeleteHouseDto> DeleteHouseAsync(string id) => _sqlHouseService.DeleteHouseAsync(id);
    }
}
