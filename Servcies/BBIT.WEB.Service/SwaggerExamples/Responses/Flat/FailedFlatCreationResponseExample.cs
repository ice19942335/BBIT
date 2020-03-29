using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat
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