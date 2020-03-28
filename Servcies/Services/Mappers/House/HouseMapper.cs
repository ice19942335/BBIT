using System;
using BBIT.Domain.Entities.DTO.House;
using BBIT.WEB.Service.Contracts.V1.Requests.House;

namespace Services.Mappers.House
{
    public static class HouseMapper
    {
        public static CreateHouseDto CreateHouseRequestToCreateHouseDto(this CreateHouseRequest createHouseRequest) => ConvertCreateHouseRequestToCreateHouseDto(createHouseRequest);

        private static CreateHouseDto ConvertCreateHouseRequestToCreateHouseDto(CreateHouseRequest createHouseRequest)
        {
            return new CreateHouseDto
            {
                HouseNumber = createHouseRequest.HouseNumber,
                StreetName = createHouseRequest.StreetName,
                City = createHouseRequest.City,
                Country = createHouseRequest.Country,
                PostCode = createHouseRequest.PostCode
            };
        }

        public static BBIT.Domain.Entities.House.House CreateDtoToHouse(this CreateHouseDto createHouseDto) => ConvertCreateHouseDtoToHouse(createHouseDto);

        private static BBIT.Domain.Entities.House.House ConvertCreateHouseDtoToHouse(CreateHouseDto createHouseDto)
        {
            return new BBIT.Domain.Entities.House.House
            {
                Id = createHouseDto.Id != null ? Guid.Parse(createHouseDto.Id) : Guid.Empty,
                HouseNumber = createHouseDto.HouseNumber,
                StreetName = createHouseDto.StreetName,
                City = createHouseDto.City,
                Country = createHouseDto.Country,
                PostCode = createHouseDto.PostCode
            };
        }

        public static CreateHouseDto HouseToCreateHouseDto(this BBIT.Domain.Entities.House.House house) => ConvertCreateHouseToCreateHouseDto(house);

        public static CreateHouseDto ConvertCreateHouseToCreateHouseDto(BBIT.Domain.Entities.House.House house)
        {
            return new CreateHouseDto
            {
                Id = house.Id.ToString(),
                HouseNumber = house.HouseNumber,
                StreetName = house.StreetName,
                City = house.City,
                Country = house.Country,
                PostCode = house.PostCode,
                Status = true
            };
        }

        public static HouseDto HouseToHouseDto(this BBIT.Domain.Entities.House.House house) => ConvertHouseToHouseDto(house);

        private static HouseDto ConvertHouseToHouseDto(BBIT.Domain.Entities.House.House house)
        {
            return new HouseDto
            {
                Id = house.Id.ToString(),
                HouseNumber = house.HouseNumber,    
                StreetName = house.StreetName,
                City = house.City,
                Country = house.Country,
                PostCode = house.PostCode
            };
        }
    }
}
