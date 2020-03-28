using System.Collections.Generic;

namespace BBIT.WEB.Service.Contracts.V1.Responses.Auth
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public bool CriticalError { get; set; }
    }
}
