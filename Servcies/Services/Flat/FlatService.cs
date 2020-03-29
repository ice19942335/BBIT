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

        public Task<CreateFlatDto> CreateFlatAsync(CreateFlatDto createFlatDto) =>
            _sqlFlatService.CreateFlatAsync(createFlatDto);
    }
}
