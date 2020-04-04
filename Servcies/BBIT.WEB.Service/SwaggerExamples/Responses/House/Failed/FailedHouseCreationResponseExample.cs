using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House.Failed
{
    public class FailedHouseCreationResponseExample : IExamplesProvider<FailedHouseCreationResponse>
    {
        public FailedHouseCreationResponse GetExamples()
        {
            return new FailedHouseCreationResponse
            {
                Status = false,
                Errors = new[] { "Some of properties are null" }
            };
        }
    }
}