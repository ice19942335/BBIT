using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.HouseExtended;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.HouseExtended
{
    public class FailedAllFlatsInHouseByHouseIdResponseExample : IExamplesProvider<FailedAllFlatsInHouseByHouseIdResponse>
    {
        public FailedAllFlatsInHouseByHouseIdResponse GetExamples()
        {
            return new FailedAllFlatsInHouseByHouseIdResponse
            {
                Errors = new []{ "Error message" },
                Status = false
            };
        }
    }
}
