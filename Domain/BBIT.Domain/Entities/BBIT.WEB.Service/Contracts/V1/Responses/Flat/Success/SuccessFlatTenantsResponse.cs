using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Tenant;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Success
{
    public class SuccessFlatTenantsResponse
    {
        public bool Status { get; set; }

        public IEnumerable<TenantDto> Tenants { get; set; }
    }
}
