using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House.Failed
{
    public class FailedAllFlatsInHouseByHouseIdResponseExample : IExamplesProvider<FailedHouseFlatsResponse>
    {
        public FailedHouseFlatsResponse GetExamples()
        {
            return new FailedHouseFlatsResponse
            {
                Errors = new []{ "Error message" },
                Status = false
            };
        }
    }
}
