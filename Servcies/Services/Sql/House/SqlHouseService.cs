using System;
using System.Linq;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.DTO.House;
using Interfaces.Sql.House;
using Services.Mappers.House;

namespace Services.Sql.House
{
    public class SqlHouseService : ISqlHouseService
    {
        private readonly BBITContext _dbContext;

        public SqlHouseService(BBITContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateHouseDto> CreateHouse(CreateHouseDto createHouseDto)
        {
            Guid id;
            do { id = Guid.NewGuid(); } while (_dbContext.Houses.FirstOrDefault(x => x.Id == id) != null);

            BBIT.Domain.Entities.House.House newHouse = createHouseDto.CreateDtoToHouse();
            newHouse.Id = id;

            await _dbContext.Houses.AddAsync(newHouse);

            try
            {
                await _dbContext.SaveChangesAsync();

                return newHouse.HouseToCreateHouseDto();
            }
            catch (Exception e)
            {
                return new CreateHouseDto
                {
                    Errors = new[] { "Error on adding new item to the database." },
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
                return new AllHousesDto
                {
                    Errors = new[] { "Error on fetch data from database" },
                    Status = false
                };
            }
        }
    }
}
