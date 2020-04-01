using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.House
{
    public class UpdateHouseDto : BaseDto
    {
        public HouseDto House { get; set; }
    }
}