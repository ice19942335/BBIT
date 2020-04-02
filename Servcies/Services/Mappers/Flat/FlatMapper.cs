using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.House;
using Services.Mappers.House;

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
                HouseId = request.HouseId,
                FlatNumber = request.FlatNumber,
                Floor = request.Floor,
                AmountOfRooms = request.AmountOfRooms,
                TotalArea = request.TotalArea,
                HouseRoom = request.HouseRoom
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
                AmountOfTenants = createFlatDto.AmountOfTenants,
                TotalArea = createFlatDto.TotalArea,
                HouseRoom = createFlatDto.HouseRoom
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
                AmountOfTenants = flat.AmountOfTenants,
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
                AmountOfTenants = flat.AmountOfTenants,
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

        #region UpdateFlatRequestToUpdateFlatDto

        public static UpdateFlatDto UpdateFlatRequestToUpdateFlatDto(this UpdateFlatRequest request) =>
            ConvertUpdateFlatRequestToUpdateFlatDto(request);

        public static UpdateFlatDto ConvertUpdateFlatRequestToUpdateFlatDto(UpdateFlatRequest request)
        {
            return new UpdateFlatDto
            {
                Flat = new FlatDto
                {
                    Id = request.Id,
                    FlatNumber = request.FlatNumber,
                    Floor = request.Floor,
                    AmountOfRooms = request.AmountOfRooms,
                    AmountOfTenants = request.AmountOfResidents,
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
                }
            };
        }

        #endregion

        #region UpdateFlatDtoToFlat

        public static BBIT.Domain.Entities.Flat.Flat UpdateFlatDtoToFlat(this BBIT.Domain.Entities.Flat.Flat flat, UpdateFlatDto updateFlatDto) =>
            ConvertUpdateFlatRequestToUpdateFlatDto(ref flat, updateFlatDto);

        private static BBIT.Domain.Entities.Flat.Flat ConvertUpdateFlatRequestToUpdateFlatDto(ref BBIT.Domain.Entities.Flat.Flat flat, UpdateFlatDto updateFlatDto)
        {
            flat.Id = Guid.Parse(updateFlatDto.Flat.Id);
            flat.FlatNumber = updateFlatDto.Flat.FlatNumber;
            flat.Floor = updateFlatDto.Flat.Floor;
            flat.AmountOfRooms = updateFlatDto.Flat.AmountOfRooms;
            flat.AmountOfTenants = updateFlatDto.Flat.AmountOfTenants;
            flat.TotalArea = updateFlatDto.Flat.TotalArea;
            flat.HouseRoom = updateFlatDto.Flat.HouseRoom;

            flat.House.Id = Guid.Parse(updateFlatDto.Flat.House.Id);
            flat.House.HouseNumber = updateFlatDto.Flat.House.HouseNumber;
            flat.House.StreetName = updateFlatDto.Flat.House.StreetName;
            flat.House.City = updateFlatDto.Flat.House.City;
            flat.House.Country = updateFlatDto.Flat.House.Country;
            flat.House.PostCode = updateFlatDto.Flat.House.PostCode;

            return flat;
        }

        #endregion

        #region FlatToUpdateFlatDto

        public static UpdateFlatDto FlatToUpdateFlatDto(this BBIT.Domain.Entities.Flat.Flat flat) =>
            ConvertFlatToUpdateFlatDto(flat);

        private static UpdateFlatDto ConvertFlatToUpdateFlatDto(this BBIT.Domain.Entities.Flat.Flat flat)
        {
            return new UpdateFlatDto
            {
                Flat = new FlatDto
                {
                    Id = flat.Id.ToString(),
                    FlatNumber = flat.FlatNumber,
                    Floor = flat.Floor,
                    AmountOfRooms = flat.AmountOfRooms,
                    AmountOfTenants = flat.AmountOfTenants,
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
                },
            };
        }

        #endregion

        #region FlatDtoToFlat

        public static BBIT.Domain.Entities.Flat.Flat FlatDtoToFlat(this FlatDto flatDto) =>
            ConvertFlatDtoToFlat(flatDto);

        private static BBIT.Domain.Entities.Flat.Flat ConvertFlatDtoToFlat(FlatDto flatDto)
        {
            return new BBIT.Domain.Entities.Flat.Flat
            {
                Id = Guid.Parse(flatDto.Id),
                FlatNumber = flatDto.FlatNumber,
                Floor = flatDto.Floor,
                AmountOfRooms = flatDto.AmountOfRooms,
                AmountOfTenants = flatDto.AmountOfTenants,
                TotalArea = flatDto.TotalArea,
                HouseRoom = flatDto.HouseRoom,
                House = flatDto.House.HouseDtoToHouse()
            };
        }

        #endregion
    }
}
