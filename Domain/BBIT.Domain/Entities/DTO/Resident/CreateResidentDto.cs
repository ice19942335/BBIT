using System.Collections.Generic;

namespace BBIT.Domain.Entities.DTO.Resident
{
    public class CreateResidentDto : ResidentDto
    {
        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }
    }
}