﻿namespace BBIT.Authentication.WEB_Service.Contracts.V1.Requests.Auth
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}