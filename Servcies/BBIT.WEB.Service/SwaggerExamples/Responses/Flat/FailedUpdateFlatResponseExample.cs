using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat
{
    public class FailedUpdateFlatResponseExample : IExamplesProvider<FailedUpdateFlatResponse>
    {
        public FailedUpdateFlatResponse GetExamples()
        {
            return new FailedUpdateFlatResponse
            {
                Errors = new []{ "Error message" },
                Status = false
            };
        }
    }
}