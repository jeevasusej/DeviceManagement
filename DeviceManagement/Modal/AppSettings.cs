using System;

namespace DeviceManagement.Modal
{
    /// <summary>
    /// Used for holding applicaiton configuration values
    /// </summary>
    public class AppSettings
    {
        /// Secret key to generate Auth token
        public string Secret { get; set; }
        /// Expiry time in minites
        public string AccessTokenExpiryMinutes { get; set; }
        /// Expiry time in minites
        public string RefreshTokenExpiryDays { get; set; }
        /// Bool value for generating new token
        public bool IsGenerateNewTokenBeforeCurrentTokenExpiry { get; set; }
        /// timespan for refresh token
        public TimeSpan RefreshTokenBefore { get; set; }
        /// Token Issuer name
        public string Issuer { get; set; }
        /// Appliation end users
        public string Audience { get; set; }
        /// Web applicaiton host url
        public string WebHostUrl { get; set; }
        public string[] AuthorizeUpdateCache { get; set; }
    }
}
