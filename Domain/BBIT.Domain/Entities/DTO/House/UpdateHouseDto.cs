using System.Collections.Generic;

namespace BBIT.Domain.Entities.DTO.House
{
    public class UpdateHouseDto : HouseDto
    {
        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }

        public bool ServerError { get; set; }
    }
}