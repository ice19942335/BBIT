using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Tenant;

namespace Interfaces.Sql.Resident
{
    public interface ISqlTenantService
    {
        Task<CreateTenantDto> CreateTenantAsync(CreateTenantDto createTenantDto);

        AllTenantsDto GetAllTenants();
    }
}
