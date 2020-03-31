using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Tenant;

namespace Interfaces.Sql.Tenant
{
    public interface ISqlTenantService
    {
        Task<CreateTenantDto> CreateTenantAsync(CreateTenantDto createTenantDto);

        AllTenantsDto GetAllTenants();

        TenantByIdDto GetTenantById(string id);
    }
}
