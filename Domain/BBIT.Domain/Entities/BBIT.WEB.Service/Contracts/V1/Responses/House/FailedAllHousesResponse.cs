using System.Collections.Generic;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House
{
    public class FailedAllHousesResponse
    {
        public bool Status { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}