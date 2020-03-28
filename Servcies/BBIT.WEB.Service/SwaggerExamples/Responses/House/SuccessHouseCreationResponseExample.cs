using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House
{
    public class SuccessHouseCreationResponseExample : IExamplesProvider<SuccessHouseCreationResponse>
    {
        public SuccessHouseCreationResponse GetExamples()
        {
            return new SuccessHouseCreationResponse
            {
                Id = "624ac106-e3c0-4df3-bca9-03015ea93987",
                HouseNumber = 56,
                StreetName = "High street",
                City = "London",
                Country = "United Kingdom",
                PostCode = "E1 7AD"
            };
        }
    }
}
