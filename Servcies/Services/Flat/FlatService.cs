using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Flat;
using Interfaces.Flat;
using Interfaces.Sql.Flat;

namespace Services.Flat
{
    public class FlatService : IFlatService
    {
        private readonly ISqlFlatService _sqlFlatService;

        public FlatService(ISqlFlatService sqlFlatService)
        {
            _sqlFlatService = sqlFlatService;
        }

        public async Task<CreateFlatDto> CreateFlatAsync(CreateFlatDto createFlatDto) =>
            await _sqlFlatService.CreateFlatAsync(createFlatDto);

        public AllFlatsDto GetAllFlats() => _sqlFlatService.GetAllFlats();

        public FlatByIdDto GetFlatById(string id) => _sqlFlatService.GetFlatById(id);

        public async Task<UpdateFlatDto> UpdateFlatAsync(UpdateFlatDto updateFlatDto) =>
            await _sqlFlatService.UpdateFlatAsync(updateFlatDto);

        public async Task<DeleteFlatDto> DeleteFlatAsync(string id) => await _sqlFlatService.DeleteFlatAsync(id);
    }
}
