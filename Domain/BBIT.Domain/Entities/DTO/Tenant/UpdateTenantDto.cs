using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Base;
using BBIT.Domain.Entities.DTO.Flat;

namespace BBIT.Domain.Entities.DTO.Tenant
{
    public class UpdateTenantDto : BaseDto
    {
        public string NewFlatId { get; set; }

        public TenantDto Tenant { get; set; }
    }
}
