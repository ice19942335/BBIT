using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant
{
    public class FailedTenantCreationResponseExample : IExamplesProvider<FailedTenantCreationResponse>
    {
        public FailedTenantCreationResponse GetExamples()
        {
            return new FailedTenantCreationResponse
            {
                Status = false,
                Errors = new []{ "Error message" }
            };
        }
    }
}