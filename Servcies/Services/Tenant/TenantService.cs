using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Tenant;
using Interfaces.Sql.Tenant;
using Interfaces.Tenant;

namespace Services.Tenant
{
    public class TenantService : ITenantService
    {
        private readonly ISqlTenantService _sqlTenantService;


        public TenantService(ISqlTenantService sqlTenantService)
        {
            _sqlTenantService = sqlTenantService;
        }

        public async Task<CreateTenantDto> CreateTenantAsync(CreateTenantDto createTenantDto) =>
            await _sqlTenantService.CreateTenantAsync(createTenantDto);

        public AllTenantsDto GetAllTenants() => _sqlTenantService.GetAllTenants();

        public TenantByIdDto GetTenantById(string id) => _sqlTenantService.GetTenantById(id);
    }
}
