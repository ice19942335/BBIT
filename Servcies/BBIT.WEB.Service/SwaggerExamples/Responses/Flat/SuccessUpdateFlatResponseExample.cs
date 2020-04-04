using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat
{
    public class SuccessUpdateFlatResponseExample : IExamplesProvider<SuccessUpdateFlatResponse>
    {
        public SuccessUpdateFlatResponse GetExamples()
        {
            return new SuccessUpdateFlatResponse
            {
                Status = true,
                Flat = new FlatDto
                {
                    Id = "ce71e57d-c18c-47ce-94a5-2363cb187a5a",
                    FlatNumber = "1",
                    Floor = 15,
                    AmountOfRooms = 5,
                    AmountOfTenants = 0,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = new HouseDto
                    {
                        Id = "77adbe2d-6f73-48ac-bf74-29167fbb89db",
                        HouseNumber = "1",
                        StreetName = "High street",
                        City = "London",
                        Country = "United Kingdom",
                        PostCode = "E1 7AD"
                    }
                }
            };
        }
    }
}