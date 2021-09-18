using System;

namespace MonitoramentoTempoOcioso
{
    struct StartWatcherEvent : IEvent
    {
        public DateTime DateTime;

        public StartWatcherEvent(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public string SerializeObject()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new {
                ds_event = "StartWatcherEvent",
                dt_event = DateTime.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }
}
