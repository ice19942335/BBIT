using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat
{
    public class SuccessFlatCreationResponseExample : IExamplesProvider<SuccessFlatCreationResponse>
    {
        public SuccessFlatCreationResponse GetExamples()
        {
            return new SuccessFlatCreationResponse
            {
                Id = "624ac106-e3c0-4df3-bca9-03015ea93987",
                FlatNumber = "1",
                Level = 15,
                AmountOfRooms = 5,
                AmountOfResidents = 4,
                TotalArea = 300,
                HouseRoom = 400,
                House = new HouseDto
                {
                    Id = "624ac106-e3c0-4df3-bca9-03015ea93987",
                    HouseNumber = "1",
                    StreetName = "High street",
                    City = "London",
                    Country = "United Kingdom",
                    PostCode = "E1 7AD"
                }
            };
        }
    }
}
