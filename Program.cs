using System;
using System.Configuration;
using System.Windows.Forms;

namespace MonitoramentoTempoOcioso
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var flagAuthorizationRequired = ConfigurationManager.AppSettings["AuthorizationRequired"];

            if (flagAuthorizationRequired != null && flagAuthorizationRequired.Equals("true")) {
                Application.Run(new LoginForm());
                return;
            }

            Application.Run(new TrayApplicationContext());
        }
    }
}
