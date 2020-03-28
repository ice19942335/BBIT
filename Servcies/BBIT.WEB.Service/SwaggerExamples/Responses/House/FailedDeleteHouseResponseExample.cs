using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House
{
    public class FailedDeleteHouseResponseExample : IExamplesProvider<FailedDeleteHouseResponse>
    {
        public FailedDeleteHouseResponse GetExamples()
        {
            return new FailedDeleteHouseResponse
            {
                Errors = new []{ "Error on deleting house from database." },
                Status = false
            };
        }
    }
}