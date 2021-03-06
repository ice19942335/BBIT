﻿using System;
using System.Linq;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant;
using BBIT.Domain.Entities.DTO.Tenant;
using Interfaces.Sql.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Mappers.Tenant;

namespace Services.Sql.Tenant
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

                BBIT.Domain.Entities.Tenant.Tenant tenant = CreateNewTenant(createTenantDto);

                var flat = GetFlatById(createTenantDto.FlatId);

                flat.AmountOfTenants++;

                tenant.Flat = flat;

                _dbContext.Flats.Update(flat);

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

        public AllTenantsDto GetAllTenants()
        {
            try
            {
                var tenantsList = _dbContext.Tenants
                    .Include(x => x.Flat)
                    .Include(x => x.Flat.House)
                    .ToList();

                return new AllTenantsDto
                {
                    Tenants = tenantsList.Select(x => x.TenantToTenantDto()),
                    Status = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on fetch data from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new AllTenantsDto
                {
                    Errors = new[] { "Error on fetch data from database." },
                    ServerError = true
                };
            }
        }

        public TenantByIdDto GetTenantById(string id)
        {
            try
            {
                var tenant = _dbContext.Tenants
                    .Include(x => x.Flat)
                    .Include(x => x.Flat.House)
                    .FirstOrDefault(x => x.Id == Guid.Parse(id));

                if (tenant is null)
                    return new TenantByIdDto { Errors = new[] { "Tenant not found" }, };

                return new TenantByIdDto
                {
                    Status = true,
                    Tenant = tenant.TenantToTenantDto()
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on fetch data from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new TenantByIdDto
                {
                    Errors = new[] { "Error on fetch data from database." },
                    ServerError = true
                };
            }
        }

        public async Task<UpdateTenantDto> UpdateTenantAsync(UpdateTenantDto updateTenantDto)
        {
            try
            {
                var tenant = _dbContext.Tenants
                        .Include(x => x.Flat)
                        .Include(x => x.Flat.House)
                        .FirstOrDefault(x => x.Id == Guid.Parse(updateTenantDto.Tenant.Id));

                if (tenant is null)
                    return new UpdateTenantDto
                    {
                        Errors = new[] { "Tenant not found." },
                        Status = false
                    };

                if(updateTenantDto.NewFlatId != null)
                {
                    var newFlatToAssign = GetFlatById(updateTenantDto.NewFlatId);

                    if(newFlatToAssign is null)
                        return new UpdateTenantDto
                        {
                            Errors = new []{ $"Flat with Id: '{updateTenantDto.NewFlatId}' not found." },
                            Status = false
                        };


                    if (tenant.Flat != null)
                    {
                        var tenantCurrentFlat = tenant.Flat;

                        if (tenantCurrentFlat.Id == Guid.Parse(updateTenantDto.NewFlatId))
                            return new UpdateTenantDto
                            {
                                Errors = new[] { "Cannot add Tenant to the same Flat" },
                                Status = false
                            };

                        tenantCurrentFlat.AmountOfTenants--;
                        newFlatToAssign.AmountOfTenants++;

                        _dbContext.Flats.Update(tenantCurrentFlat);
                    }
                    else
                    {
                        tenant.Flat = newFlatToAssign;
                        newFlatToAssign.AmountOfTenants++;
                    }

                    tenant.Flat = newFlatToAssign;
                    tenant.Name = updateTenantDto.Tenant.Name;
                    tenant.Surname = updateTenantDto.Tenant.Surname;
                    tenant.PersonalCode = updateTenantDto.Tenant.PersonalCode;
                    tenant.DateOfBirth = Convert.ToDateTime(updateTenantDto.Tenant.DateOfBirth);
                    tenant.PhoneNumber = updateTenantDto.Tenant.PhoneNumber;
                    tenant.Email = updateTenantDto.Tenant.Email;

                    
                    _dbContext.Flats.Update(newFlatToAssign);
                    _dbContext.Tenants.Update(tenant);
                    await _dbContext.SaveChangesAsync();

                    return new UpdateTenantDto
                    {
                        Status = true,
                        Tenant = tenant.TenantToTenantDto()
                    };
                }

                tenant.Name = updateTenantDto.Tenant.Name;
                tenant.Surname = updateTenantDto.Tenant.Surname;
                tenant.PersonalCode = updateTenantDto.Tenant.PersonalCode;
                tenant.DateOfBirth = Convert.ToDateTime(updateTenantDto.Tenant.DateOfBirth);
                tenant.PhoneNumber = updateTenantDto.Tenant.PhoneNumber;
                tenant.Email = updateTenantDto.Tenant.Email;

                _dbContext.Tenants.Update(tenant);
                await _dbContext.SaveChangesAsync();

                return new UpdateTenantDto
                {
                    Status = true,
                    Tenant = tenant.TenantToTenantDto()
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on updating Tenant in database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new UpdateTenantDto
                {
                    Errors = new[] { "Error on updating Tenant in database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public async Task<DeleteTenantDto> DeleteTenantAsync(string id)
        {
            try
            {
                var tenant = _dbContext.Tenants
                    .Include(x => x.Flat)
                    .FirstOrDefault(x => x.Id == Guid.Parse(id));

                if (tenant is null)
                    return new DeleteTenantDto
                    {
                        Status = false,
                        Errors = new[] { $"Tenant with Id: '{id}' not found." }
                    };

                tenant.Flat.AmountOfTenants--;

                _dbContext.Tenants.Remove(tenant);
                await _dbContext.SaveChangesAsync();

                return new DeleteTenantDto { Status = true };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on deleting Tenant from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new DeleteTenantDto
                {
                    Errors = new[] { "Error on deleting Tenant from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }


        #region PrivateMethods

        private bool CheckTenantExist(CreateTenantDto createTenantDto)
        {
            var tenant = _dbContext.Tenants
                .ToList()
                .FirstOrDefault(x =>
                x.Name == createTenantDto.Tenant.Name &&
                x.Surname == createTenantDto.Tenant.Surname &&
                x.DateOfBirth.ToString("d") == Convert.ToDateTime(createTenantDto.Tenant.DateOfBirth).ToString("d") &&
                x.PersonalCode == createTenantDto.Tenant.PersonalCode);

            return tenant != null;
        }

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

        private BBIT.Domain.Entities.Tenant.Tenant CreateNewTenant(CreateTenantDto createTenantDto)
        {
            Guid id;
            do { id = Guid.NewGuid(); } while (_dbContext.Tenants.FirstOrDefault(x => x.Id == id) != null);

            return new BBIT.Domain.Entities.Tenant.Tenant
            {
                Id = id,
                Name = createTenantDto.Tenant.Name,
                Surname = createTenantDto.Tenant.Surname,
                PersonalCode = createTenantDto.Tenant.PersonalCode,
                DateOfBirth = Convert.ToDateTime(createTenantDto.Tenant.DateOfBirth),
                PhoneNumber = createTenantDto.Tenant.PhoneNumber,
                Email = createTenantDto.Tenant.Email
            };
        }

        #endregion

    }
}
