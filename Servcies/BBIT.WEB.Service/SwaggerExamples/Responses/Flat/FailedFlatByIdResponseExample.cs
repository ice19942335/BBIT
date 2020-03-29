using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat
{
    public class FailedFlatByIdResponseExample : IExamplesProvider<FailedFlatByIdResponse>
    {
        public FailedFlatByIdResponse GetExamples()
        {
            return new FailedFlatByIdResponse
            {
                Errors = new[] { "Error message" },
                Status = false
            };
        }
    }
}