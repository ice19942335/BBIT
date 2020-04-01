using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;
using BBIT.Domain.Entities.DTO.Tenant;

namespace Interfaces.Sql.Tenant
{
    public interface ISqlTenantService
    {
        Task<CreateTenantDto> CreateTenantAsync(CreateTenantDto createTenantDto);

        AllTenantsDto GetAllTenants();

        TenantByIdDto GetTenantById(string id);

        Task<UpdateTenantDto> UpdateTenantAsync(UpdateTenantDto updateTenantDto);

        Task<DeleteTenantDto> DeleteTenantAsync(string id);
    }
}
