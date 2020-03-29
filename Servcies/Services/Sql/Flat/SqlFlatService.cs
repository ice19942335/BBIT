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
                var flat = _dbContext.Flats.Include(x => x.House).FirstOrDefault(x => x.FlatNumber == createFlatDto.FlatNumber && x.House.Id == Guid.Parse(createFlatDto.House.Id));
                if (flat != null)
                    return new CreateFlatDto
                    {
                        Errors = new[] { $"Flat with number: '{createFlatDto.FlatNumber}' in house: '{flat.House.Country}, {flat.House.City}, {flat.House.StreetName}, {flat.House.HouseNumber}' already exist" },
                        Status = false,
                        ServerError = false
                    };

                var house = _dbContext.Houses.FirstOrDefault(x => x.Id == Guid.Parse(createFlatDto.House.Id));

                if (house is null)
                    return new CreateFlatDto
                    {
                        Errors = new[] { $"House with Id: '{createFlatDto.House.Id}' not found" },
                        Status = false,
                        ServerError = false
                    };

                Guid id;
                do { id = Guid.NewGuid(); } while (_dbContext.Flats.FirstOrDefault(x => x.Id == id) != null);

                BBIT.Domain.Entities.Flat.Flat newFlat = createFlatDto.CreateFlatDtoToFlat();
                newFlat.Id = id;
                newFlat.House = house;

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
                var flatsDtoList = _dbContext.Flats.Include(x => x.House).ToList();
                flatsDtoList.ForEach(x => x.AmountOfResidents = _dbContext.FlatResident.Count(xx => xx.FlatId == x.Id));

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
    }
}
