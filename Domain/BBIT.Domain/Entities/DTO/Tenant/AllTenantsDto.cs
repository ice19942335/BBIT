using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.Tenant
{
    public class AllTenantsDto : BaseDto
    {
        public IEnumerable<TenantDto> Tenants { get; set; }
    }
}
