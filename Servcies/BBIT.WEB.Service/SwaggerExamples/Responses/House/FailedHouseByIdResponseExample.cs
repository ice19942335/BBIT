using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House
{
    public class FailedHouseByIdResponseExample : IExamplesProvider<FailedHouseByIdResponse>
    {
        public FailedHouseByIdResponse GetExamples()
        {
            return new FailedHouseByIdResponse
            {
                Status = false,
                Errors = new[] { "Item not found." }
            };
        }
    }
}