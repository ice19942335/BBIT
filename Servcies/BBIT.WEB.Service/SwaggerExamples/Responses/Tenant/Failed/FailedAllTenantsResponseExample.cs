using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant.Failed
{
    public class FailedAllTenantsResponseExample : IExamplesProvider<FailedAllTenantsResponse>
    {
        public FailedAllTenantsResponse GetExamples()
        {
            return new FailedAllTenantsResponse
            {
                Status = false,
                Errors = new []{ "Error message" }
            };
        }
    }
}
