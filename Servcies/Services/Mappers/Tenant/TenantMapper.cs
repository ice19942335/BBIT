using System;
using System.Collections.Generic;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.Tenant;
using Services.Mappers.Flat;

namespace Services.Mappers.Tenant
{
    public static class TenantMapper
    {
        #region CreateTenantRequestToCreateTenantDto

        public static CreateTenantDto CreateTenantRequestToCreateTenantDto(this CreateTenantRequest request) =>
            ConvertCreateTenantRequestToCreateTenantDto(request);

        private static CreateTenantDto ConvertCreateTenantRequestToCreateTenantDto(CreateTenantRequest request)
        {
            return new CreateTenantDto
            {
                FlatId = request.FlatId,
                Tenant = new TenantDto
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    PersonalCode = request.PersonalCode,
                    DateOfBirth = request.DateOfBirth.ToString("d"),
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email
                },
            };
        }

        #endregion

        #region CreateTenantDtoToTenant

        public static BBIT.Domain.Entities.Tenant.Tenant CreateTenantDtoToTenant(
            this CreateTenantDto createTenantDto) => ConvertCreateTenantDtoToTenant(createTenantDto);

        private static BBIT.Domain.Entities.Tenant.Tenant ConvertCreateTenantDtoToTenant(CreateTenantDto createTenantDto)
        {
            return new BBIT.Domain.Entities.Tenant.Tenant
            {
                Name = createTenantDto.Tenant.Name,
                Surname = createTenantDto.Tenant.Surname,
                PersonalCode = createTenantDto.Tenant.PersonalCode,
                DateOfBirth = Convert.ToDateTime(createTenantDto.Tenant.DateOfBirth),
                PhoneNumber = createTenantDto.Tenant.PhoneNumber,
                Email = createTenantDto.Tenant.Email
            };
        }

        #endregion

        #region TenantDtoToCreateTenantDto

        public static CreateTenantDto TenantDtoToCreateTenantDto(this BBIT.Domain.Entities.Tenant.Tenant tenant) =>
            ConvertTenantDtoToCreateTenantDto(tenant);

        private static CreateTenantDto ConvertTenantDtoToCreateTenantDto(
            BBIT.Domain.Entities.Tenant.Tenant tenant)
        {
            return new CreateTenantDto
            {
                Tenant = new TenantDto
                {
                    Id = tenant.Id.ToString(),
                    Name = tenant.Name,
                    Surname = tenant.Surname,
                    PersonalCode = tenant.PersonalCode,
                    DateOfBirth = tenant.DateOfBirth.ToString("d"),
                    PhoneNumber = tenant.PhoneNumber,
                    Email = tenant.Email,
                    Flat = tenant.Flat?.FlatToFlatDto()
                }
            };
        }

        #endregion

        #region TenantToTenantDto

        public static TenantDto TenantToTenantDto(this BBIT.Domain.Entities.Tenant.Tenant tenant) =>
            ConvertTenantToTenantDto(tenant);

        private static TenantDto ConvertTenantToTenantDto(BBIT.Domain.Entities.Tenant.Tenant tenant)
        {
            return new TenantDto
            {
                Id = tenant.Id.ToString(),
                Name = tenant.Name,
                Surname = tenant.Surname,
                PersonalCode = tenant.PersonalCode,
                DateOfBirth = tenant.DateOfBirth.ToString("d"),
                PhoneNumber = tenant.PhoneNumber,
                Email = tenant.Email,
                Flat = tenant.Flat?.FlatToFlatDto()
            };
        }

        #endregion

        #region UpdateTenantRequestToUpdateTenantDto

        public static UpdateTenantDto UpdateTenantRequestToUpdateTenantDto(this UpdateTenantRequest request) =>
            ConvertUpdateTenantRequestToUpdateTenantDto(request);

        private static UpdateTenantDto ConvertUpdateTenantRequestToUpdateTenantDto(UpdateTenantRequest request)
        {
            return new UpdateTenantDto
            {
                Tenant = new TenantDto
                {
                    Id = request.Id,
                    Name = request.Name,
                    Surname = request.Surname,
                    PersonalCode = request.PersonalCode,
                    DateOfBirth = request.DateOfBirth.ToString("d"),
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email
                },
                NewFlatId = request.NewFlatId
            };
        }

        #endregion

        #region UpdateTenantDtoToTenant

        public static BBIT.Domain.Entities.Tenant.Tenant UpdateTenantDtoToTenant(this UpdateTenantDto updateTenantDto) =>
            ConvertUpdateTenantDtoToTenant(updateTenantDto);

        private static BBIT.Domain.Entities.Tenant.Tenant ConvertUpdateTenantDtoToTenant(UpdateTenantDto updateTenantDto)
        {
            return new BBIT.Domain.Entities.Tenant.Tenant
            {
                Id = Guid.Parse(updateTenantDto.Tenant.Id),
                Name = updateTenantDto.Tenant.Name,
                Surname = updateTenantDto.Tenant.Surname,
                PersonalCode = updateTenantDto.Tenant.PersonalCode,
                DateOfBirth = Convert.ToDateTime(updateTenantDto.Tenant.DateOfBirth),
                PhoneNumber = updateTenantDto.Tenant.PhoneNumber,
                Email = updateTenantDto.Tenant.Email
            }; 
        }

        #endregion
    }
}
