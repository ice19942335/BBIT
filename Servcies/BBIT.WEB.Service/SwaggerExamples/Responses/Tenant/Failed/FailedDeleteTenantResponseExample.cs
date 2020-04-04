using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant.Failed
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
