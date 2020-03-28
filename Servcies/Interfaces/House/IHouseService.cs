using System.Collections.Generic;
using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.House;

namespace Interfaces.House
{
    public interface IHouseService
    {
        Task<CreateHouseDto> CreateHouseAsync(CreateHouseDto createHouseDto);

        AllHousesDto GetAllHouses();
    }
}
