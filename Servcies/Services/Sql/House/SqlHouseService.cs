using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.DTO.House;
using Interfaces.Sql.House;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Mappers.House;

namespace Services.Sql.House
{
    public class SqlHouseService : ISqlHouseService
    {
        private readonly BBITContext _dbContext;
        private readonly ILogger<SqlHouseService> _logger;

        public SqlHouseService(BBITContext dbContext, ILogger<SqlHouseService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CreateHouseDto> CreateHouseAsync(CreateHouseDto createHouseDto)
        {
            var house = _dbContext.Houses.FirstOrDefault(x =>
                x.Country == createHouseDto.House.Country &&
                x.City == createHouseDto.House.City &&
                x.StreetName == createHouseDto.House.StreetName &&
                x.HouseNumber == createHouseDto.House.HouseNumber);

            if (house != null)
                return new CreateHouseDto
                {
                    Errors = new[] { $"House with address: '{house.Country}, {house.City}, {house.StreetName}, {house.HouseNumber}' already exist" },
                    Status = false,
                    ServerError = false
                };

            Guid id;
            do { id = Guid.NewGuid(); } while (_dbContext.Houses.FirstOrDefault(x => x.Id == id) != null);

            BBIT.Domain.Entities.House.House newHouse = createHouseDto.CreateDtoToHouse();
            newHouse.Id = id;

            await _dbContext.Houses.AddAsync(newHouse);

            try
            {
                await _dbContext.SaveChangesAsync();

                var newHouseDtoToReturn = newHouse.HouseToCreateHouseDto();
                newHouseDtoToReturn.Status = true;

                return newHouseDtoToReturn;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on adding new house into database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new CreateHouseDto
                {
                    Errors = new[] { "Error on adding new house into database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public AllHousesDto GetAllHouses()
        {
            try
            {
                return new AllHousesDto
                {
                    Houses = _dbContext.Houses.Select(x => x.HouseToHouseDto()),
                    Status = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on fetch data from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new AllHousesDto
                {
                    Errors = new[] { "Error on fetch data from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public HouseByIdDto GetHouseById(string id)
        {
            try
            {
                return new HouseByIdDto
                {
                    House = _dbContext.Houses.FirstOrDefault(x => x.Id == Guid.Parse(id)).HouseToHouseDto(),
                    Status = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on fetch data from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new HouseByIdDto
                {
                    Errors = new[] { "Error on fetch data from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public async Task<UpdateHouseDto> UpdateHouse(UpdateHouseDto updateHouseDto)
        {
            try
            {
                BBIT.Domain.Entities.House.House house =
                    _dbContext.Houses.FirstOrDefault(x => x.Id == Guid.Parse(updateHouseDto.House.Id));

                if (house is null)
                    return new UpdateHouseDto
                    {
                        Errors = new []{ "Item not found" },
                        Status = false
                    };

                house = updateHouseDto.UpdateHouseDtoToHouse();

                _dbContext.Houses.Update(house);
                await _dbContext.SaveChangesAsync();

                var newUpdateHouseDto = house.HouseToUpdateHouseDto();
                newUpdateHouseDto.Status = true;

                return newUpdateHouseDto;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on updating house in database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new UpdateHouseDto
                {
                    Errors = new[] { "Error on updating house in database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public async Task<DeleteHouseDto> DeleteHouseAsync(string id)
        {
            try
            {
                var house = _dbContext.Houses.FirstOrDefault(x => x.Id == Guid.Parse(id));

                if (house is null)
                    return new DeleteHouseDto
                    {
                        Status = false,
                        Errors = new[] { "House not found." }
                    };

                var flatsToDelete = _dbContext.Flats
                    .Include(x => x.House)
                    .Where(x => x.House.Id == house.Id)
                    .ToList();

                var tenantsToDelete = _dbContext.Tenants
                    .Include(x => x.Flat)
                    .Include(x => x.Flat.House)
                    .Where(x => x.Flat.House.Id == house.Id)
                    .ToList();

                _dbContext.Tenants.RemoveRange(tenantsToDelete);
                _dbContext.Flats.RemoveRange(flatsToDelete);
                _dbContext.Houses.Remove(house);
                await _dbContext.SaveChangesAsync();

                return new DeleteHouseDto { Status = true };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on deleting house from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new DeleteHouseDto
                {
                    Errors = new[] { "Error on deleting house from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }
    }
}
