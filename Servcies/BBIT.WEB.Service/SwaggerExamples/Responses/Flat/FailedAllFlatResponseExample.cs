using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat
{
    public class FailedAllFlatResponseExample : IExamplesProvider<FailedAllFlatResponse>
    {
        public FailedAllFlatResponse GetExamples()
        {
            return new FailedAllFlatResponse
            {
                Errors = new[] { "Error message" },
                Status = false
            };
        }
    }
}