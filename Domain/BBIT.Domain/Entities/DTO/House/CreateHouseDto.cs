using System.Collections.Generic;

namespace BBIT.Domain.Entities.DTO.House
{
    public class CreateHouseDto : HouseDto
    {
        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }
    }
}
