using System.Collections.Generic;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class CreateFlatDto : FlatDto
    {
        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }
    }
}