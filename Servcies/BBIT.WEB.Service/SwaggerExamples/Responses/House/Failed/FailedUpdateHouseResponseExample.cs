using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House.Failed
{
    public class FailedUpdateHouseResponseExample : IExamplesProvider<FailedUpdateHouseResponse>
    {
        public FailedUpdateHouseResponse GetExamples()
        {
            return new FailedUpdateHouseResponse
            {
                Status = false,
                Errors = new []{ "Error on updating house in database." }
            };
        }
    }
}