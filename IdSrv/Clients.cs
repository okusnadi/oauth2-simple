using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdSrv
{
    static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                //no human involved
                new Client {
                    ClientName = "FreightShare Client", //uniqueName
                    ClientId = "freightshare1", //uniqueId
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference, //reference tokens do not need a signing certificate
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<Secret> 
                    {
                        new Secret("IIPiBTywUcK5Qv0kvmVXbSiax5wBStDMGTAIA0T/RSM=".Sha256()) //to authenticate client against the token endpoint
                    },
                    AllowedScopes = new List<string>
                    {
                        "api1"
                    }
                },

                //human is involved
                new Client {
                    ClientName = "FreightShare on behalf of PowerBI client",
                    ClientId = "freightshare2", //uniqueId
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,
                    Flow = Flows.ResourceOwner,
                    ClientSecrets = new List<Secret> 
                    {
                        new Secret("IIPiBTywUcK5Qv0kvmVXbSiax5wBStDMGTAIA0T/RSM=".Sha256()) //to authenticate client against the token endpoint
                    },
                    AllowedScopes = new List<string>
                    {
                        "api1"
                    }
                }
            };
        }
    }
}
