using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.Tenant
{
    public class CreateTenantDto : BaseDto
    {
        public string FlatId { get; set; }

        public TenantDto Tenant { get; set; }
    }
}