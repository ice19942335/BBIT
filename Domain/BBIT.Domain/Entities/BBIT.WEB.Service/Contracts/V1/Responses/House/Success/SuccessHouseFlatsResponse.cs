using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Flat;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Success
{
    public class SuccessHouseFlatsResponse
    {
        public bool Status { get; set; }

        public IEnumerable<FlatDto> Flats { get; set; }
    }
}
