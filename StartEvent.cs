using System;

namespace MonitoramentoTempoOcioso
{
    struct StartEvent : IEvent
    {
        public DateTime DateTime;

        public StartEvent(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public string SerializeObject()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new {
                ds_event = "StartEvent",
                dt_event = DateTime.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }
}
