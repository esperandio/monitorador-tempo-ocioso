using MonitoramentoTempoOcioso.Interfaces.Users;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MonitoramentoTempoOcioso.Entities.Users
{
    public class AuthenticatedUser : IUser
    {
        private static readonly HttpClient s_client = new HttpClient();
        private readonly string _token;

        private AuthenticatedUser(string token)
        {
            _token = token;
        }

        public static async Task<AuthenticatedUser> AuthenticateAsync(string userName, string password)
        {
            var response = await s_client.PutAsync(
                "http://localhost:3334/login",
                new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(
                        new {
                            email = userName,
                            senha = password
                        }
                    ), 
                    Encoding.UTF8, 
                    "application/json"
                )
            );

            response.EnsureSuccessStatusCode();

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthenticatedUserData>(
                response.Content.ReadAsStringAsync().Result
            );

            return new AuthenticatedUser(result.token);
        }

        public string Identifier()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new {
                    token = _token
                }
            );
        }
    }
}
