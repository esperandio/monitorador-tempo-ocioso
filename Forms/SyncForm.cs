using MonitoramentoTempoOcioso.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MonitoramentoTempoOcioso.Forms
{
    public partial class SyncForm : Form
    {
        private readonly IEventRepository _eventRepository;

        public SyncForm(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void SyncForm_Load(object sender, EventArgs e)
        {
            var eventsToSync = _eventRepository.GetEventsToSync();

            lblEventsToSync.Text += eventsToSync.Count;
            lblSyncedWithSuccess.Text += "0";

            pgbSync.Style = ProgressBarStyle.Marquee;
            pgbSync.MarqueeAnimationSpeed = 30;
        }
    }
}
