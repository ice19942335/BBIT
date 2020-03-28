using System;
using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.Entities.DTO.House
{
    public class DeleteHouseDto
    {
        public bool Status { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool ServerError { get; set; }
    }
}
