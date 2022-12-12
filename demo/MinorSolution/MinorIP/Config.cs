using Duende.IdentityServer.Models;
using IdentityModel;

namespace MinorIP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };


    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("kaasapi.read", new string[] { JwtClaimTypes.Name }) { Scopes = new string[] { "lieveapi" } }
        };


    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("lieveapi") { UserClaims = new[] { JwtClaimTypes.Name } },
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "blazorbff",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:7012/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7012/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7012/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "lieveapi" }
            },
        };
}