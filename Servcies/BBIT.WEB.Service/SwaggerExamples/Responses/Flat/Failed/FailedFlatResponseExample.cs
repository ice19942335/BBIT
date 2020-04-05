using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat.Failed
{
    public class FailedFlatResponseExample : IExamplesProvider<FailedFlatResponse>
    {
        public FailedFlatResponse GetExamples()
        {
            return new FailedFlatResponse
            {
                Errors = new[] { "Error message" },
                Status = false
            };
        }
    }
}