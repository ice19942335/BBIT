using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House
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
