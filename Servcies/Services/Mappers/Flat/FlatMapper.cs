using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.House;

namespace Services.Mappers.Flat
{
    public static class FlatMapper
    {
        #region CreateFlatRequestToCreateFlatDto

        public static CreateFlatDto CreateFlatRequestToCreateFlatDto(this CreateFlatRequest request) =>
            ConvertCreateFlatRequestToCreateFlatDto(request);

        private static CreateFlatDto ConvertCreateFlatRequestToCreateFlatDto(CreateFlatRequest request)
        {
            return new CreateFlatDto
            {
                FlatNumber = request.FlatNumber,
                Floor = request.Floor,
                AmountOfRooms = request.AmountOfRooms,
                TotalArea = request.TotalArea,
                HouseRoom = request.HouseRoom,
                House = new HouseDto
                {
                    Id = request.House.Id,
                    HouseNumber = request.House.HouseNumber,
                    StreetName = request.House.StreetName,
                    City = request.House.City,
                    Country = request.House.Country,
                    PostCode = request.House.PostCode
                }
            };
        }

        #endregion

        #region CreateFlatDtoToFlat

        public static BBIT.Domain.Entities.Flat.Flat CreateFlatDtoToFlat(this CreateFlatDto createFlatDto) =>
            ConvertCreateFlatDtoToFlat(createFlatDto);

        private static BBIT.Domain.Entities.Flat.Flat ConvertCreateFlatDtoToFlat(CreateFlatDto createFlatDto)
        {
            return new BBIT.Domain.Entities.Flat.Flat
            {
                Id = createFlatDto.Id != null ? Guid.Parse(createFlatDto.Id) : Guid.Empty,
                FlatNumber = createFlatDto.FlatNumber,
                Floor = createFlatDto.Floor,
                AmountOfRooms = createFlatDto.AmountOfRooms,
                AmountOfResidents = createFlatDto.AmountOfResidents,
                TotalArea = createFlatDto.TotalArea,
                HouseRoom = createFlatDto.HouseRoom,
                House = new BBIT.Domain.Entities.House.House
                {
                    Id = Guid.Parse(createFlatDto.House.Id),
                    HouseNumber = createFlatDto.House.HouseNumber,
                    StreetName = createFlatDto.House.StreetName,
                    City = createFlatDto.House.City,
                    Country = createFlatDto.House.Country,
                    PostCode = createFlatDto.House.PostCode
                }
            };
        }

        #endregion

        #region FlatToCreateFlatDto

        public static CreateFlatDto FlatToCreateFlatDto(this BBIT.Domain.Entities.Flat.Flat flat) =>
            ConvertFlatToCreateFlatDto(flat);

        private static CreateFlatDto ConvertFlatToCreateFlatDto(BBIT.Domain.Entities.Flat.Flat flat)
        {
            return new CreateFlatDto
            {
                Id = flat.Id.ToString(),
                FlatNumber = flat.FlatNumber,
                Floor = flat.Floor,
                AmountOfRooms = flat.AmountOfRooms,
                AmountOfResidents = flat.AmountOfResidents,
                TotalArea = flat.TotalArea,
                HouseRoom = flat.HouseRoom,
                House = new HouseDto
                {
                    Id = flat.House.Id.ToString(),
                    HouseNumber = flat.House.HouseNumber,
                    StreetName = flat.House.StreetName,
                    City = flat.House.City,
                    Country = flat.House.Country,
                    PostCode = flat.House.PostCode
                }
            };
        }

        #endregion

        #region FlatToFlatDto

        public static FlatDto FlatToFlatDto(this BBIT.Domain.Entities.Flat.Flat flat) => ConvertFlatToFlatDto(flat);

        private static FlatDto ConvertFlatToFlatDto(BBIT.Domain.Entities.Flat.Flat flat)
        {
            return new FlatDto
            {
                Id = flat.Id.ToString(),
                FlatNumber = flat.FlatNumber,
                Floor = flat.Floor,
                AmountOfRooms = flat.AmountOfRooms,
                AmountOfResidents = flat.AmountOfResidents,
                TotalArea = flat.TotalArea,
                HouseRoom = flat.HouseRoom,
                House = new HouseDto
                {
                    Id = flat.House.Id.ToString(),
                    HouseNumber = flat.House.HouseNumber,
                    StreetName = flat.House.StreetName,
                    City = flat.House.City,
                    Country = flat.House.Country,
                    PostCode = flat.House.PostCode
                }
            };
        }

        #endregion
    }
}
