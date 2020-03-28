using System;
using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.Entities.DTO.House
{
    public class AllHousesDto
    {
        public IEnumerable<HouseDto> Houses { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }

        public bool ServerError { get; set; }
    }
}
