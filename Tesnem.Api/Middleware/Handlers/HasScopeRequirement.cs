using Microsoft.AspNetCore.Authorization;

namespace Tesnem.Api.Middleware.Handlers
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirement(string scope)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = "https://tesnem-auth.azurewebsites.net/connect/token";
        }
    }
}
