using BBIT.Authentication.WEB_Service.Contracts.V1.Requests.Auth;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.Authentication.WEB_Service.SwaggerExamples.Requests.Auth
{
    public class UserRegistrationRequestExample : IExamplesProvider<UserRegistrationRequest>
    {
        public UserRegistrationRequest GetExamples()
        {
            return new UserRegistrationRequest
            {
                Name = "Sam",
                Email = "sam.atkins@gmail.com",
                Password = "Password123!"
            };
        }
    }
}