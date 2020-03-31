using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Tenant
{
    public class SuccessUpdateTenantResponseExample : IExamplesProvider<SuccessUpdateTenantResponse>
    {
        public SuccessUpdateTenantResponse GetExamples()
        {
            return new SuccessUpdateTenantResponse
            {
                Id = "4644e41b-c19e-4f24-96f3-013103030c5a",
                Name = "Name",
                Surname = "Surname",
                PersonalCode = "12345",
                DateOfBirth = DateTime.Today,
                PhoneNumber = "+37112345678",
                Email = "email@mail.com",
                Flat = new FlatDto
                {
                    Id = "ce71e57d-c18c-47ce-94a5-2363cb187a5a",
                    FlatNumber = 45,
                    Floor = 15,
                    AmountOfRooms = 5,
                    AmountOfResidents = 0,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = new HouseDto
                    {
                        Id = "77adbe2d-6f73-48ac-bf74-29167fbb89db",
                        HouseNumber = 50,
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
