using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Auth;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Requests.Auth
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