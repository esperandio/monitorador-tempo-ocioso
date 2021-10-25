using MonitoramentoTempoOcioso.Interfaces.Users;
using System;

namespace MonitoramentoTempoOcioso.Entities.Users
{
    class LocalUser : IUser
    {
        private readonly string _environmentUserName;
        private readonly string _environmentMachineName;

        public LocalUser()
        {
            _environmentMachineName = Environment.MachineName.ToString();
            _environmentUserName = Environment.UserName;
        }

        public string Identifier()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new {
                    ds_user_name = _environmentUserName,
                    ds_machine_name = _environmentMachineName
                }
            );
        }
    }
}
