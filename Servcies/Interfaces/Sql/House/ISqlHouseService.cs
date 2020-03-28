using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.House;

namespace Interfaces.Sql.House
{
    public interface ISqlHouseService
    {
        Task<CreateHouseDto> CreateHouse(CreateHouseDto createHouseDto);

        AllHousesDto GetAllHouses();
    }
}
