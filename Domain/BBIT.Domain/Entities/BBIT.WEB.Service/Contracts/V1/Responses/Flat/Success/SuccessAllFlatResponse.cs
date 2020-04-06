using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Flat;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Success
{
    public class SuccessAllFlatResponse
    {
        public IEnumerable<FlatDto> Flats { get; set; }

        public bool Status { get; set; }
    }
}
