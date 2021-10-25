using MonitoramentoTempoOcioso.Interfaces.Events;
using System;

namespace MonitoramentoTempoOcioso.Entities.Events
{
    struct IdleTimeEvent : IEvent
    {
        public DateTime DateTime;
        public uint MillisecondsIdle;

        public IdleTimeEvent(DateTime dateTime, uint millisecondsIdle)
        {
            DateTime = dateTime;
            MillisecondsIdle = millisecondsIdle;
        }

        public string SerializeObject()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { 
                ds_event = "IdleTimeEvent",
                dt_event = DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                nr_milliseconds_idle = MillisecondsIdle
            });
        }
    }
}
