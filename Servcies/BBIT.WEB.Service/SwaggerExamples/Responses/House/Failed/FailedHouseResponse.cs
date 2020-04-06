using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House.Failed
{
    public class FailedHouseResponse : IExamplesProvider<Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed.FailedHouseResponse>
    {
        public Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed.FailedHouseResponse GetExamples()
        {
            return new Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed.FailedHouseResponse
            {
                Errors = new []{ "Error message" },
                Status = false
            };
        }
    }
}
