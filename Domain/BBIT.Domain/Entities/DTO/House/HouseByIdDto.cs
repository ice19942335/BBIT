using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.House
{
    public class HouseByIdDto : BaseDto
    {
        public HouseDto House { get; set; }
    }
}
