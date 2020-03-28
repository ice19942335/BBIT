using System;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.House;
using BBIT.Domain.Entities.DTO.House;

namespace Services.Mappers.House
{
    public static class HouseMapper
    {
        #region CreateHouseRequestToCreateHouseDto

        public static CreateHouseDto CreateHouseRequestToCreateHouseDto(this CreateHouseRequest createHouseRequest) =>
            ConvertCreateHouseRequestToCreateHouseDto(createHouseRequest);
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

        #endregion

        #region CreateDtoToHouse

        public static BBIT.Domain.Entities.House.House CreateDtoToHouse(this CreateHouseDto createHouseDto) =>
            ConvertCreateHouseDtoToHouse(createHouseDto);
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

        #endregion

        #region HouseToCreateHouseDto

        public static CreateHouseDto HouseToCreateHouseDto(this BBIT.Domain.Entities.House.House house) =>
            ConvertCreateHouseToCreateHouseDto(house);
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

        #endregion

        #region HouseToHouseDto

        public static HouseDto HouseToHouseDto(this BBIT.Domain.Entities.House.House house) =>
            ConvertHouseToHouseDto(house);
        private static HouseDto ConvertHouseToHouseDto(BBIT.Domain.Entities.House.House house)
        {
            if (house != null)
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

            return null;
        }

        #endregion

        #region UpdateHouseRequestToUpdateHouseDto

        public static UpdateHouseDto UpdateHouseRequestToUpdateHouseDto(this UpdateHouseRequest request) =>
            ConvertUpdateHouseRequestToUpdateHouseDto(request);
        private static UpdateHouseDto ConvertUpdateHouseRequestToUpdateHouseDto(UpdateHouseRequest request)
        {
            return new UpdateHouseDto
            {
                Id = request.Id,
                HouseNumber = request.HouseNumber,
                StreetName = request.StreetName,
                City = request.City,
                Country = request.Country,
                PostCode = request.PostCode
            };
        }

        #endregion

        #region UpdateHouseDtoToHouse

        public static BBIT.Domain.Entities.House.House UpdateHouseDtoToHouse(this UpdateHouseDto updateHouseDto) =>
            ConvertUpdateHouseDtoToHouse(updateHouseDto);
        private static BBIT.Domain.Entities.House.House ConvertUpdateHouseDtoToHouse(UpdateHouseDto updateHouseDto)
        {
            return new BBIT.Domain.Entities.House.House
            {
                Id = Guid.Parse(updateHouseDto.Id),
                HouseNumber = updateHouseDto.HouseNumber,
                StreetName = updateHouseDto.StreetName,
                City = updateHouseDto.City,
                Country = updateHouseDto.Country,
                PostCode = updateHouseDto.PostCode
            };
        }

        #endregion

        #region HouseToUpdateHouseDto

        public static UpdateHouseDto HouseToUpdateHouseDto(this BBIT.Domain.Entities.House.House house) =>
            ConvertHouseToUpdateHouseDto(house);
        private static UpdateHouseDto ConvertHouseToUpdateHouseDto(BBIT.Domain.Entities.House.House house)
        {
            return new UpdateHouseDto
            {
                Id = house.Id.ToString(),
                HouseNumber = house.HouseNumber,
                StreetName = house.StreetName,
                City = house.City,
                Country = house.Country,
                PostCode = house.PostCode
            };
        }

        #endregion

        #region UpdateHouseDtoToHouseDto

        public static HouseDto UpdateHouseDtoToHouseDto(this UpdateHouseDto updateHouseDto) =>
            ConvertUpdateHouseDtoToHouseDto(updateHouseDto);
        private static HouseDto ConvertUpdateHouseDtoToHouseDto(UpdateHouseDto updateHouseDto)
        {
            return new HouseDto
            {
                Id = updateHouseDto.Id,
                HouseNumber = updateHouseDto.HouseNumber,
                StreetName = updateHouseDto.StreetName,
                City = updateHouseDto.City,
                Country = updateHouseDto.Country,
                PostCode = updateHouseDto.PostCode
            };
        }

        #endregion
    }
}