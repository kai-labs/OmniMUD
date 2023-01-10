using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OmniMud.WebClient.Models
{
    public class AzureGoogleAuthenticationMiddleware
    {
        private readonly RequestDelegate next;

        public AzureGoogleAuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var googleTokenText = context.Request.Headers["X-MS-TOKEN-GOOGLE-ID-TOKEN"];            

            if (string.IsNullOrEmpty(googleTokenText))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var token = new JwtSecurityTokenHandler().ReadJwtToken(googleTokenText);
            var principal = new ClaimsPrincipal(new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme));
            context.User = principal;

            await next(context);
        }
    }
}
