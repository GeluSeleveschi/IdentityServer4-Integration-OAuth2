using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer4Integration.Configuration
{
    public class InMemoryConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        public static List<TestUser> GetUsers() =>
            new List<TestUser>
            {
                new TestUser
                {
                      SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                      Username = "Jordan Peterson",
                      Password = "YouShouldBeAMonster",
                      Claims = new List<Claim>
                      {
                          new Claim("given_name", "Jordan"),
                          new Claim("family_name", "Peterson")
                      }
                },
                 new TestUser
                {
                      SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                      Username = "Garry Vee",
                      Password = "IfYouWantToBeAnAnomalyYouHaveToActLikeOne",
                      Claims = new List<Claim>
                      {
                          new Claim("given_name", "Jordan"),
                          new Claim("family_name", "Peterson")
                      }
                }
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "company-employee",
                    ClientSecrets = new[]{new Secret ("mysecretcode".Sha512())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId}
                }
            };
    }
}
