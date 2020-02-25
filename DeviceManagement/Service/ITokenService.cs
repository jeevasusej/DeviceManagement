using System.Collections.Generic;
using System.Security.Claims;

namespace DeviceManagement.Services
{
    /// <summary>
    /// Token service to generate token
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generate access toke with the claims
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        string GenerateAccessToken(IEnumerable<Claim> claims);

        /// <summary>
        /// Generate refresh token
        /// </summary>
        /// <returns></returns>
        string GenerateRefreshToken();

        /// <summary>
        /// Get principal from the expired token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        /// <summary>
        /// Get principal from the token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        ClaimsPrincipal GetPrincipal(string token);
    }
}
