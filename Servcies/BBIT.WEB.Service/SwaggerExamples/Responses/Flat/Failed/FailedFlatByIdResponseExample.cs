using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat.Failed
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