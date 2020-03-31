using System;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant
{
    public class FailedUpdateTenantResponseExample : IExamplesProvider<FailedUpdateTenantResponse>
    {
        public FailedUpdateTenantResponse GetExamples()
        {
            return new FailedUpdateTenantResponse
            {
                Status = false,
                Errors = new[] { "Error message" }
            };
        }
    }
}