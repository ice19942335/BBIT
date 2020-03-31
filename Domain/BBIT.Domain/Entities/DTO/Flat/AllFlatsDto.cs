using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class AllFlatsDto : BaseDto
    {
        public IEnumerable<FlatDto> Flats { get; set; }
    }
}
