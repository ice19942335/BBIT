﻿using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Success;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.House.Success
{
    public class SuccessAllFlatsInHouseByHouseIdResponseExample : IExamplesProvider<SuccessHouseFlatsResponse>
    {
        public SuccessHouseFlatsResponse GetExamples()
        {
            return new SuccessHouseFlatsResponse
            {
                Status = true,
                Flats = new[]
                {
                    new FlatDto
                    {
                        Id = "ce71e57d-c18c-47ce-94a5-2363cb187a5a",
                        FlatNumber = "1",
                        Level = 15,
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
                    },
                    new FlatDto
                    {
                        Id = "ce71e57d-c18c-47ce-94a5-2363cb187a5a",
                        FlatNumber = "1",
                        Level = 15,
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
                    },
                    new FlatDto
                    {
                        Id = "ce71e57d-c18c-47ce-94a5-2363cb187a5a",
                        FlatNumber = "1",
                        Level = 15,
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
                    },
                },
            };
        }
    }
}
