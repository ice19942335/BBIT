using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Auth;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Auth
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
