using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant.Failed
{
    public class FailedTenantResponseExample : IExamplesProvider<FailedTenantResponse>
    {
        public FailedTenantResponse GetExamples()
        {
            return new FailedTenantResponse
            {
                Status = false,
                Errors = new []{ "Error message" }
            };
        }
    }
}
