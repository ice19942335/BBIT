using System;
using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class AllFlatsDto
    {
        public IEnumerable<FlatDto> Flats { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }

        public bool ServerError { get; set; }
    }
}
