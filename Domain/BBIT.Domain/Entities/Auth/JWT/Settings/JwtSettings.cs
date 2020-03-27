using System;

namespace BBIT.Domain.Entities.Auth.JWT.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }

        public TimeSpan TokenLifetime { get; set; }
    }
}
