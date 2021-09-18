using System;

namespace MonitoramentoTempoOcioso
{
    struct StartApplicationEvent : IEvent
    {
        public DateTime DateTime;

        public StartApplicationEvent(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public string SerializeObject()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                ds_event = "StartApplicationEvent",
                dt_event = DateTime.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }
}
