namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Auth
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
