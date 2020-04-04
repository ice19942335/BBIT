using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.Tenant;
using Interfaces.Flat;
using Interfaces.Sql.Flat;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Mappers.Flat;
using Services.Mappers.Tenant;

namespace Services.Flat
{
    public class FlatService : IFlatService
    {
        private readonly ISqlFlatService _sqlFlatService;
        private readonly BBITContext _dbContext;
        private readonly ILogger<FlatService> _logger;

        public FlatService(ISqlFlatService sqlFlatService, BBITContext dbContext, ILogger<FlatService> logger)
        {
            _sqlFlatService = sqlFlatService;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CreateFlatDto> CreateFlatAsync(CreateFlatDto createFlatDto) =>
            await _sqlFlatService.CreateFlatAsync(createFlatDto);

        public AllFlatsDto GetAllFlats() => _sqlFlatService.GetAllFlats();

        public FlatByIdDto GetFlatById(string id) => _sqlFlatService.GetFlatById(id);

        public async Task<UpdateFlatDto> UpdateFlatAsync(UpdateFlatDto updateFlatDto) =>
            await _sqlFlatService.UpdateFlatAsync(updateFlatDto);

        public async Task<DeleteFlatDto> DeleteFlatAsync(string id) => await _sqlFlatService.DeleteFlatAsync(id);

        public AllTenantsDto GetFlatTenants(string id)
        {
            try
            {
                var flat = _dbContext.Flats
                    .Include(x => x.House)
                    .FirstOrDefault(x => x.Id == Guid.Parse(id));

                if (flat is null)
                    return new AllTenantsDto
                    {
                        Errors = new[] { "Flat not found." },
                        ItemNotFound = true
                    };

                var tenants = _dbContext.Tenants
                    .Include(x => x.Flat)
                    .Include(x => x.Flat.House)
                    .Where(x => x.Flat.Id == Guid.Parse(id))
                    .ToList()
                    .OrderBy(x => x.Flat.House.HouseNumber);

                return new AllTenantsDto
                {
                    Status = true,
                    Tenants = tenants.Select(x => x.TenantToTenantDto())
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on fetching data from database. Exception message: {e.Message};\nInner message: {e.InnerException?.Message}");
                return new AllTenantsDto
                {
                    Errors = new[] { "Error on fetching data from database." },
                    ServerError = true,
                    Status = false
                };
            }
        }
    }
}
