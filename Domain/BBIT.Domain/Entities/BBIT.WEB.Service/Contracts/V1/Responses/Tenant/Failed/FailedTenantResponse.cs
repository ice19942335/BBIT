using System.Collections.Generic;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant.Failed
{
    public class FailedTenantResponse
    {
        public bool Status { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
