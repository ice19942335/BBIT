using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Requests.Flat
{
    public class CreateFlatRequestExample : IExamplesProvider<CreateFlatRequest>
    {
        public CreateFlatRequest GetExamples()
        {
            return new CreateFlatRequest
            {
                FlatNumber = 45,
                Floor = 15,
                AmountOfRooms = 5,
                AmountOfResidents = 4,
                TotalArea = 300,
                HouseRoom = 400,
                House = new HouseDto
                {
                    Id = "624ac106-e3c0-4df3-bca9-03015ea93987",
                    HouseNumber = 56,
                    StreetName = "High street",
                    City = "London",
                    Country = "United Kingdom",
                    PostCode = "E1 7AD"
                }
            };
        }
    }
}
