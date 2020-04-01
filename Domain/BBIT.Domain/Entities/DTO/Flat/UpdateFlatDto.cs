using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class UpdateFlatDto : BaseDto
    {
        public FlatDto Flat { get; set; }
    }
}
