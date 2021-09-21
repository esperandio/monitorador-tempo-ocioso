using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonitoramentoTempoOcioso
{
    class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly IEventRepository _eventRepository;
        private readonly IdleTimeWatcher _idleTimeWatcher;

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

            _notifyIcon.ContextMenuStrip.Items[1].Enabled = false;

            _notifyIcon.Visible = true;

            _eventRepository = new SQLiteEventRepository();
            _idleTimeWatcher = new IdleTimeWatcher(_eventRepository);

            _eventRepository.Add(new StartApplicationEvent(DateTime.Now));
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
            _notifyIcon.ContextMenuStrip.Items[0].Enabled = false;
            _notifyIcon.ContextMenuStrip.Items[1].Enabled = true;

            _notifyIcon.Icon = new Icon("Resources/start.ico");

            _idleTimeWatcher.Start();
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            _notifyIcon.ContextMenuStrip.Items[0].Enabled = true;
            _notifyIcon.ContextMenuStrip.Items[1].Enabled = false;

            _notifyIcon.Icon = new Icon("Resources/stop.ico");

            _idleTimeWatcher.Stop();
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            _notifyIcon.Dispose();

            _ = MessageBox.Show(
                "Quantidade de eventos registrados: " + _eventRepository.Count().ToString(),
                "Status",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            _eventRepository.Add(new ExitApplicationEvent(DateTime.Now));

            Application.Exit();
        }
    }
}
