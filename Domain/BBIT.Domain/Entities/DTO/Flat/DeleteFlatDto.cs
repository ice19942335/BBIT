using System;
using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class DeleteFlatDto
    {
        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }

        public bool ServerError { get; set; }
    }
}
