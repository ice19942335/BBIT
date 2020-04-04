using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant.Failed
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