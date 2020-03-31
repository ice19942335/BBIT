using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.House
{
    public class CreateHouseDto : BaseDto
    {
        public HouseDto House { get; set; }
    }
}
