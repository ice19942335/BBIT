using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT.WEB.Service.Contracts.V1.Responses.House
{
    public class FailedHouseCreationResponse
    {
        public bool Status { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
