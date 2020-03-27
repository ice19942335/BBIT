using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Authentication.WEB_Service.Contracts.V1.Responses.Auth;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.Authentication.WEB_Service.SwaggerExamples.Responses.Auth
{
    public class AuthFailedResponseExample : IExamplesProvider<AuthFailedResponse>
    {
        public AuthFailedResponse GetExamples()
        {
            return new AuthFailedResponse
            {
                Errors = new[] { "Error message, show to user if not critical" },
                CriticalError = false
            };
        }
    }
}
