using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat.Failed
{
    public class FailedFlatTenantsResponseExample : IExamplesProvider<FailedFlatTenantsResponse>
    {
        public FailedFlatTenantsResponse GetExamples()
        {
            return new FailedFlatTenantsResponse
            {
                Status = false,
                Errors = new[] { "Error message" }
            };
        }
    }
}