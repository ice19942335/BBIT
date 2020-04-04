using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat.Failed
{
    public class FailedFlatCreationResponseExample : IExamplesProvider<FailedFlatCreationResponse>
    {
        public FailedFlatCreationResponse GetExamples()
        {
            return new FailedFlatCreationResponse
            {
                Status = false,
                Errors = new[] { "House with Id: '...' not found" }
            };
        }
    }
}