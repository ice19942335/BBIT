using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class FlatByIdDto : BaseDto
    {
        public FlatDto Flat { get; set; }
    }
}
