using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Flat;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat
{
    public class SuccessAllFlatResponse
    {
        public IEnumerable<FlatDto> Flats { get; set; }

        public bool Status { get; set; }
    }
}
