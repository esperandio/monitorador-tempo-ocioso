using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MonitoramentoTempoOcioso
{
    class AuthenticatedUser : IUser
    {
        private static readonly HttpClient s_client = new HttpClient();
        private readonly string _userName;

        private AuthenticatedUser(string userName)
        {
            _userName = userName;
        }

        public static async Task<AuthenticatedUser> AuthenticateAsync(string userName, string password)
        {
            var response = await s_client.PostAsync(
                "http://api.webhookinbox.com/i/x0GhMH52/ina/",
                new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(
                        new {
                            ds_user_name = userName,
                            ds_password = password
                        }
                    ), 
                    Encoding.UTF8, 
                    "application/json"
                )
            );

            response.EnsureSuccessStatusCode();

            return new AuthenticatedUser(userName);
        }

        public string Identifier()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new {
                    ds_user_name = _userName
                }
            );
        }
    }
}
