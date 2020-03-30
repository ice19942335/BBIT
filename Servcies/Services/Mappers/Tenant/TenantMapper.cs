using System.Collections.Generic;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;
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
                    DateOfBirth = request.DateOfBirth,
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
                DateOfBirth = createTenantDto.Tenant.DateOfBirth,
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
                    DateOfBirth = tenant.DateOfBirth,
                    PhoneNumber = tenant.PhoneNumber,
                    Email = tenant.Email,
                    Flat = tenant.Flat.FlatToFlatDto()
                }
            };
        }

        #endregion
    }
}
