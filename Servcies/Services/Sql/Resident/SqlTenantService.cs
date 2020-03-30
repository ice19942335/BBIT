using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.DTO.House;
using BBIT.Domain.Entities.DTO.Tenant;
using BBIT.Domain.Entities.Flat;
using BBIT.Domain.Entities.Tenant;
using Interfaces.Sql.Resident;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Mappers.Tenant;

namespace Services.Sql.Resident
{
    public class SqlTenantService : ISqlTenantService
    {
        private readonly BBITContext _dbContext;
        private readonly ILogger<SqlTenantService> _logger;

        public SqlTenantService(BBITContext dbContext, ILogger<SqlTenantService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CreateTenantDto> CreateTenantAsync(CreateTenantDto createTenantDto)
        {
            try
            {
                if (createTenantDto.FlatId != null && !CheckFlatExist(createTenantDto.FlatId))
                    return new CreateTenantDto { Errors = new[] { $"Flat with Id: '{createTenantDto.FlatId}' not exist." } };

                if (createTenantDto.FlatId != null && !CheckHouseExistByFlatId(createTenantDto.FlatId))
                    return new CreateTenantDto { Errors = new[] { $"House with (Flat Id: '{createTenantDto.FlatId}') not exist." } };

                if (CheckTenantExist(createTenantDto))
                    return new CreateTenantDto { Errors = new[] { $"Tenant with provided details already exist." } };

                Tenant tenant = CreateNewTenant(createTenantDto);

                if (createTenantDto.FlatId != null)
                    tenant.Flat = GetFlatById(createTenantDto.FlatId);

                await _dbContext.Tenants.AddAsync(tenant);
                await _dbContext.SaveChangesAsync();

                var createTenantDtoToReturn = tenant.TenantDtoToCreateTenantDto();
                createTenantDtoToReturn.Status = true;

                return createTenantDtoToReturn;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on creating Tenant in database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new CreateTenantDto
                {
                    Errors = new[] { "Error on creating Tenant in database." },
                    ServerError = true
                };
            }
        }


        #region PrivateMethods

        private bool CheckTenantExist(CreateTenantDto createTenantDto) =>
            _dbContext.Tenants.FirstOrDefault(x =>
                x.Name == createTenantDto.Tenant.Name &&
                x.Surname == createTenantDto.Tenant.Surname &&
                x.DateOfBirth == createTenantDto.Tenant.DateOfBirth &&
                x.Email == createTenantDto.Tenant.Email &&
                x.PersonalCode == createTenantDto.Tenant.PersonalCode &&
                x.PhoneNumber == createTenantDto.Tenant.PhoneNumber) != null;

        private bool CheckFlatExist(string flatId) => _dbContext.Flats.FirstOrDefault(x => x.Id == Guid.Parse(flatId)) != null;

        private bool CheckHouseExistByFlatId(string flatId)
        {
            if (!CheckFlatExist(flatId))
                return false;

            var flat = _dbContext.Flats
                .Include(x => x.House)
                .FirstOrDefault(x => x.Id == Guid.Parse(flatId));

            return flat?.House != null;
        }

        private BBIT.Domain.Entities.Flat.Flat GetFlatById(string flatId) =>
            _dbContext.Flats.Include(x => x.House).FirstOrDefault(x => x.Id == Guid.Parse(flatId));

        private Tenant CreateNewTenant(CreateTenantDto createTenantDto)
        {
            Guid id;
            do { id = Guid.NewGuid(); } while (_dbContext.Tenants.FirstOrDefault(x => x.Id == id) != null);

            return new Tenant
            {
                Id = id,
                Name = createTenantDto.Tenant.Name,
                Surname = createTenantDto.Tenant.Surname,
                PersonalCode = createTenantDto.Tenant.PersonalCode,
                DateOfBirth = createTenantDto.Tenant.DateOfBirth,
                PhoneNumber = createTenantDto.Tenant.PhoneNumber,
                Email = createTenantDto.Tenant.Email
            };
        }

        #endregion

    }
}
