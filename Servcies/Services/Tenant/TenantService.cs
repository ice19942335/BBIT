using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Tenant;
using Interfaces.Resident;
using Interfaces.Sql.Resident;

namespace Services.Resident
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
    }
}
