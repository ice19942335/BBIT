using System;
using BBIT.Domain.Entities.DTO.House;
using BBIT.WEB.Service.Contracts.V1.Requests.House;

namespace Services.Mappers.House
{
    public static class HouseMapper
    {
        public static CreateHouseDto RequestToHouseDto(this CreateHouseRequest request) => ConvertRequestToHouseDto(request);

        private static CreateHouseDto ConvertRequestToHouseDto(CreateHouseRequest request)
        {
            return new CreateHouseDto
            {
                HouseNumber = request.HouseNumber,
                StreetName = request.StreetName,
                City = request.City,
                Country = request.Country,
                PostCode = request.PostCode
            };
        }

        public static BBIT.Domain.Entities.House.House DtoToHouse(this CreateHouseDto createHouseDto) => ConvertHouseDtoToHouse(createHouseDto);

        private static BBIT.Domain.Entities.House.House ConvertHouseDtoToHouse(CreateHouseDto createHouseDto)
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

        public static CreateHouseDto HouseToDto(this BBIT.Domain.Entities.House.House house) => ConvertHouseToHouseDto(house);

        public static CreateHouseDto ConvertHouseToHouseDto(BBIT.Domain.Entities.House.House house)
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
    }
}
