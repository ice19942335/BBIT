using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.Tenant;

namespace Interfaces.Flat
{
    public interface IFlatService
    {
        Task<CreateFlatDto> CreateFlatAsync(CreateFlatDto createFlatDto);

        AllFlatsDto GetAllFlats();

        FlatByIdDto GetFlatById(string id);

        Task<UpdateFlatDto> UpdateFlatAsync(UpdateFlatDto updateFlatDto);

        Task<DeleteFlatDto> DeleteFlatAsync(string id);

        AllTenantsDto GetFlatTenants(string id);
    }
}
