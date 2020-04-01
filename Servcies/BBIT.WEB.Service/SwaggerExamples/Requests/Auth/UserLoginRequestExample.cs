using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Auth;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Requests.Auth
{
    public class UserLoginRequestExample : IExamplesProvider<UserLoginRequest>
    {
        public UserLoginRequest GetExamples()
        {
            return new UserLoginRequest
            {
                Username = "sam.atkins@gmail.com",
                Password = "Password123!"
            };
        }
    }
}