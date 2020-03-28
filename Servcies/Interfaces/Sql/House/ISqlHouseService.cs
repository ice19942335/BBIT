using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.House;

namespace Interfaces.Sql.House
{
    public interface ISqlHouseService
    {
        Task<CreateHouseDto> CreateHouse(CreateHouseDto createHouseDto);

        AllHousesDto GetAllHouses();

        HouseByIdDto GetHouseById(string id);

        Task<UpdateHouseDto> UpdateHouse(UpdateHouseDto updateHouseDto);
    }
}
