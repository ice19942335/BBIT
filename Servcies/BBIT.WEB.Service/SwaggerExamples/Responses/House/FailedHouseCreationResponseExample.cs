using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House
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