using System;

namespace MonitoramentoTempoOcioso
{
    struct StopEvent : IEvent
    {
        public DateTime DateTime;

        public StopEvent(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public string SerializeObject()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new {
                ds_event = "StopEvent",
                dt_event = DateTime.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }
}
