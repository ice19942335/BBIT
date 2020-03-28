using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House
{
    public class SuccessHousesByIdResponseExample : IExamplesProvider<SuccessHouseByIdResponse>
    {
        public SuccessHouseByIdResponse GetExamples()
        {
            return new SuccessHouseByIdResponse
            {
                House = new HouseDto
                {
                    Id = "624ac106-e3c0-4df3-bca9-03015ea93987".ToString(),
                    HouseNumber = 56,
                    StreetName = "High street",
                    City = "London",
                    Country = "United Kingdom",
                    PostCode = "E1 7AD"
                },
                Status = true
            };  
        }
    }
}