using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Flat;

namespace Interfaces.Sql.Flat
{
    public interface ISqlFlatService
    {
        Task<CreateFlatDto> CreateFlatAsync(CreateFlatDto createFlatDto);
    }
}
