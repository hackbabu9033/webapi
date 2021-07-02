using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace exercise.Provider
{
    public class ApiAuthServiceProvider : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }

        //public override async Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
        //{
        //    var a = 1;
        //}

        //public override async Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        //{
        //    var a = 1;
        //}

        //public override async Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
        //{
        //    var a = 1;
        //}

        //public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        //{
        //    var a = 1;
        //}

        //public override async Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        //{
        //    var a = 1;
        //}

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var userName = context.UserName;
            var password = context.Password;
            var owinRequestBody = context.Request.Body;
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hi Admin"));
                context.Validated(identity);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hi User"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }


        //public override async Task MatchEndpoint(OAuthMatchEndpointContext context)
        //{
        //    var a = 1;
        //}

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

        //public override async Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        //{
        //    var a = 1;
        //}

        //public override async Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
        //{
        //    var a = 1;
        //}

        //public override async Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        //{
        //    var a = 1;
        //}

        //public override async Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        //{
        //    var a = 1;
        //}
    }
}