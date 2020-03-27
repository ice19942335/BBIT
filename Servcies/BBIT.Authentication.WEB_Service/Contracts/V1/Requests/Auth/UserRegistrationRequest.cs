using System.ComponentModel.DataAnnotations;

namespace BBIT.Authentication.WEB_Service.Contracts.V1.Requests.Auth
{
    public class UserRegistrationRequest
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
