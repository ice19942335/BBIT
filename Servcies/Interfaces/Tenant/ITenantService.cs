using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;
using BBIT.Domain.Entities.DTO.Tenant;

namespace Interfaces.Tenant
{
    public interface ITenantService
    {
        Task<CreateTenantDto> CreateTenantAsync(CreateTenantDto createTenantDto);

        AllTenantsDto GetAllTenants();

        TenantByIdDto GetTenantById(string id);

        Task<UpdateTenantDto> UpdateTenantAsync(UpdateTenantDto updateTenantDto);
    }
}
