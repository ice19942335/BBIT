using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Tenant;

namespace Interfaces.Resident
{
    public interface ITenantService
    {
        Task<CreateTenantDto> CreateTenantAsync(CreateTenantDto createTenantDto);
    }
}
