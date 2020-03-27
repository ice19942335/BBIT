using System;
using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.DTO.Auth
{
    public class AuthenticationDto
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool CriticalError { get; set; }
    }
}
