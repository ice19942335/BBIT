using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant
{
    public class FailedTenantByIdResponseExample : IExamplesProvider<FailedTenantByIdResponse>
    {
        public FailedTenantByIdResponse GetExamples()
        {
            return new FailedTenantByIdResponse
            {
                Status = false,
                Errors = new []{ "Error message" }
            };
        }
    }
}