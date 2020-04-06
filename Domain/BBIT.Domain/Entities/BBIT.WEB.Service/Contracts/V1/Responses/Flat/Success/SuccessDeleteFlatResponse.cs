using System.Collections.Generic;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Success
{
    public class FailedDeleteFlatResponse
    {
        public bool Status { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
