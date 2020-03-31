﻿using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Tenant;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant
{
    public class SuccessAllTenantsResponse
    {
        public bool Status { get; set; }

        public IEnumerable<TenantDto> Tenants { get; set; }
    }
}
