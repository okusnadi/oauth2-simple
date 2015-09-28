using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("client running...");
            var response = GetClientToken();
            CallApi(response);

            Console.WriteLine("client resource owner running...");
            var response2 = GetUserToken();
            CallApi(response2);
            Console.ReadLine();
        }

        static TokenResponse GetClientToken()
        {
            var client = new TokenClient("https://localhost:44333/connect/token",
                                          "freightshare1",
                                          "IIPiBTywUcK5Qv0kvmVXbSiax5wBStDMGTAIA0T/RSQ=");

            return client.RequestClientCredentialsAsync("api1").Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:14869/test").Result);
        }

        /// <summary>
        /// Request an access token on behalf of a user
        /// </summary>
        static TokenResponse GetUserToken()
        {
            var client = new TokenClient("https://localhost:44333/connect/token",
                                          "freightshare2",
                                          "IIPiBTywUcK5Qv0kvmVXbSiax5wBStDMGTAIA0T/RSQ=");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "api1").Result;
        }
    }
}
