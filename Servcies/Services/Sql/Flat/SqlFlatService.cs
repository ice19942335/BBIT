using System;
using System.Linq;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.DTO.Flat;
using Interfaces.Sql.Flat;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Mappers.Flat;

namespace Services.Sql.Flat
{
    public class SqlFlatService : ISqlFlatService
    {
        private readonly BBITContext _dbContext;
        private readonly ILogger<SqlFlatService> _logger;

        public SqlFlatService(BBITContext dbContext, ILogger<SqlFlatService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CreateFlatDto> CreateFlatAsync(CreateFlatDto createFlatDto)
        {
            try
            {
                var flat = _dbContext.Flats.Include(x => x.House).FirstOrDefault(x => x.FlatNumber == createFlatDto.FlatNumber && x.House.Id == Guid.Parse(createFlatDto.HouseId));
                if (flat != null)
                    return new CreateFlatDto
                    {
                        Errors = new[] { $"Flat with number: '{createFlatDto.FlatNumber}' in house: '{flat.House.Country}, {flat.House.City}, {flat.House.StreetName}, {flat.House.HouseNumber}' already exist" },
                        Status = false,
                        ServerError = false
                    };

                var house = _dbContext.Houses.FirstOrDefault(x => x.Id == Guid.Parse(createFlatDto.HouseId));

                if (house is null)
                    return new CreateFlatDto
                    {
                        Errors = new[] { $"House with Id: '{createFlatDto.HouseId}' not found" },
                        Status = false,
                        ServerError = false
                    };

                Guid id;
                do { id = Guid.NewGuid(); } while (_dbContext.Flats.FirstOrDefault(x => x.Id == id) != null);

                BBIT.Domain.Entities.Flat.Flat newFlat = createFlatDto.CreateFlatDtoToFlat();
                newFlat.Id = id;
                newFlat.House = house;
                newFlat.AmountOfTenants = 0; //Just make sure Flat have 0 tenant on creation.

                await _dbContext.Flats.AddAsync(newFlat);
                await _dbContext.SaveChangesAsync();

                createFlatDto = newFlat.FlatToCreateFlatDto();
                createFlatDto.Status = true;

                return createFlatDto;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on adding new flat into database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new CreateFlatDto
                {
                    Errors = new[] { "Error on adding new flat into database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public AllFlatsDto GetAllFlats()
        {
            try
            {
                var flatsDtoList = _dbContext.Flats
                    .Include(x => x.House)
                    .ToList();

                return new AllFlatsDto
                {
                    Flats = flatsDtoList.Select(x => x.FlatToFlatDto()),
                    Status = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on fetch data from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new AllFlatsDto
                {
                    Errors = new[] { "Error on fetch data from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public FlatByIdDto GetFlatById(string id)
        {
            try
            {
                var flat = _dbContext.Flats
                    .Include(x => x.House)
                    .FirstOrDefault(x => x.Id == Guid.Parse(id));

                if (flat is null)
                    return new FlatByIdDto
                    {
                        Errors = new[] { $"Flat not found" },
                        Status = false,
                        ServerError = false
                    };

                return new FlatByIdDto
                {
                    Flat = flat.FlatToFlatDto(),
                    Status = true,
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on fetch data from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new FlatByIdDto
                {
                    Errors = new[] { "Error on fetch data from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public async Task<UpdateFlatDto> UpdateFlatAsync(UpdateFlatDto updateFlatDto)
        {
            try
            {
                var flat = _dbContext.Flats
                        .Include(x => x.House)
                        .FirstOrDefault(x => x.Id == Guid.Parse(updateFlatDto.Flat.Id));

                if (_dbContext.Flats.FirstOrDefault(x => x.Id == Guid.Parse(updateFlatDto.Flat.Id)) is null)
                    return new UpdateFlatDto
                    {
                        Errors = new[] { "Item not found" },
                        Status = false
                    };

                //Can not make Flat duplicate because of EF Core
                flat = flat.FlatDtoToFlat(updateFlatDto);

                _dbContext.Flats.Update(flat);
                await _dbContext.SaveChangesAsync();

                var updatedFlatDto = flat.FlatToUpdateFlatDto();
                updatedFlatDto.Status = true;

                return updatedFlatDto;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on updating Flat in database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new UpdateFlatDto
                {
                    Errors = new[] { "Error on updating Flat in database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

        public async Task<DeleteFlatDto> DeleteFlatAsync(string id)
        {
            try
            {
                var flat = _dbContext.Flats.FirstOrDefault(x => x.Id == Guid.Parse(id));

                if (flat is null)
                    return new DeleteFlatDto
                    {
                        Status = false,
                        Errors = new[] { "Flat not found." }
                    };

                var tenantsToDelete = _dbContext.Tenants
                    .Include(x => x.Flat)
                    .Include(x => x.Flat.House)
                    .Where(x => x.Flat != null && x.Flat.Id == flat.Id)
                    .ToList();

                _dbContext.Tenants.RemoveRange(tenantsToDelete);
                _dbContext.Flats.Remove(flat);
                await _dbContext.SaveChangesAsync();

                return new DeleteFlatDto { Status = true };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on deleting Flat from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new DeleteFlatDto
                {
                    Errors = new[] { "Error on deleting Flat from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }

    }
}
