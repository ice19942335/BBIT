using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Base;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class CreateFlatDto : BaseDto
    {
        public FlatDto Flat { get; set; }
    }
}