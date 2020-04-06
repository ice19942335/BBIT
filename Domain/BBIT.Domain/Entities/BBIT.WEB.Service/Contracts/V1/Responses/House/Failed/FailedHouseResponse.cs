using System.Collections.Generic;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Failed
{
    public class FailedHouseResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }
    }
}