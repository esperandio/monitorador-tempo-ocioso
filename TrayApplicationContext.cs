using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonitoradorTempoOcioso
{
    class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;

        public TrayApplicationContext()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = new Icon("Resources/default.ico"),
                Text = "Monitorador de tempo ocioso",
                ContextMenuStrip = new ContextMenuStrip()
            };

            _notifyIcon.ContextMenuStrip.Items.Add("Iniciar monitoramento", Image.FromFile("Resources/start.ico"), OnStartClicked);
            _notifyIcon.ContextMenuStrip.Items.Add("Pausar monitoramento", Image.FromFile("Resources/stop.ico"), OnStopClicked);
            _notifyIcon.ContextMenuStrip.Items.Add("Finalizar aplicação", null, OnExitClicked);

            _notifyIcon.Visible = true;
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            _notifyIcon.Dispose();
            Application.Exit();
        }
    }
}
