using System;
using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat
{
    public class FailedDeleteFlatResponse
    {
        public bool Status { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
