using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.House;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.House;

namespace Interfaces.House
{
    public interface IHouseService
    {
        Task<CreateHouseDto> CreateHouseAsync(CreateHouseDto createHouseDto);

        AllHousesDto GetAllHouses();

        HouseByIdDto GetHouseById(string id);

        Task<UpdateHouseDto> UpdateHouseAsync(UpdateHouseDto updateHouseDto);

        Task<DeleteHouseDto> DeleteHouseAsync(string id);

        AllFlatsDto GetAllFlatsInHouseByHouseId(string id);
    }
}
