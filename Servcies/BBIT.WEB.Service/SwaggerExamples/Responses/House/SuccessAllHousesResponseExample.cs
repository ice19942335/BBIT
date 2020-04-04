using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House
{
    public class SuccessAllHousesResponseExample : IExamplesProvider<SuccessAllHousesResponse>
    {
        public SuccessAllHousesResponse GetExamples()
        {
            return new SuccessAllHousesResponse
            {
                Status = true,
                Houses = new []
                {
                    new HouseDto
                    {
                        Id = "624ac106-e3c0-4df3-bca9-03015ea93987".ToString(),
                        HouseNumber = "1",
                        StreetName = "High street",
                        City = "London",
                        Country = "United Kingdom",
                        PostCode = "E1 7AD"
                    },
                    new HouseDto
                    {
                        Id = "624ac106-e3c0-4df3-bca9-03015ea93987".ToString(),
                        HouseNumber = "2",
                        StreetName = "High street",
                        City = "London",
                        Country = "United Kingdom",
                        PostCode = "E1 7AD"
                    },
                    new HouseDto
                    {
                        Id = "624ac106-e3c0-4df3-bca9-03015ea93987".ToString(),
                        HouseNumber = "3",
                        StreetName = "High street",
                        City = "London",
                        Country = "United Kingdom",
                        PostCode = "E1 7AD"
                    },
                }
            };
        }
    }
}
