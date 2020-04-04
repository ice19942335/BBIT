using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House.Failed
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