using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.House;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Requests.House
{
    public class CreateHouseRequestExample : IExamplesProvider<CreateHouseRequest>
    {
        public CreateHouseRequest GetExamples()
        {
            return new CreateHouseRequest
            {
                HouseNumber = 56,
                StreetName = "High street",
                City = "London",
                Country = "United Kingdom",
                PostCode = "E1 7AD"
            };
        }
    }
}
