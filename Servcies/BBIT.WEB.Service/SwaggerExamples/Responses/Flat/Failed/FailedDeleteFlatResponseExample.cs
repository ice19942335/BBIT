using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Success;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat.Failed
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