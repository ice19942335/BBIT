using System.ComponentModel.DataAnnotations;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Auth
{
    public class UserLoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
