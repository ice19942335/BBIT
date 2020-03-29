using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat
{
    public class FailedDeleteFlatResponseExample : IExamplesProvider<FailedDeleteFlatResponse>
    {
        public FailedDeleteFlatResponse GetExamples()
        {
            return new FailedDeleteFlatResponse
            {
                Status = false,
                Errors = new[] { "Error message" }
            };
        }
    }
}