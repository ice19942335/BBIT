using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House.Failed
{
    public class FailedAllHousesResponseExample : IExamplesProvider<FailedAllHousesResponse>
    {
        public FailedAllHousesResponse GetExamples()
        {
            return new FailedAllHousesResponse
            {
                Status = false,
                Errors = new[] { "Error on fetch data from database." }
            };
        }
    }
}
