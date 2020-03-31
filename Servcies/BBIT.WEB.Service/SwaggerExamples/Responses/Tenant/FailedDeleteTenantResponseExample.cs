using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant
{
    public class FailedDeleteTenantResponseExample : IExamplesProvider<FailedDeleteTenantResponse>
    {
        public FailedDeleteTenantResponse GetExamples()
        {
            return new FailedDeleteTenantResponse
            {
                Errors = new []{ "Error message" },
                Status = false
            };
        }
    }
}
