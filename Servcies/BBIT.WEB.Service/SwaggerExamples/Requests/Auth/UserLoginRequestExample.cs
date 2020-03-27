using BBIT.Authentication.WEB_Service.Contracts.V1.Requests.Auth;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.Authentication.WEB_Service.SwaggerExamples.Requests.Auth
{
    public class UserLoginRequestExample : IExamplesProvider<UserLoginRequest>
    {
        public UserLoginRequest GetExamples()
        {
            return new UserLoginRequest
            {
                Email = "sam.atkins@gmail.com",
                Password = "Password123!"
            };
        }
    }
}