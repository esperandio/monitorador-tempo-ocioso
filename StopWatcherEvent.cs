﻿using System;

namespace MonitoramentoTempoOcioso
{
    struct StopWatcherEvent : IEvent
    {
        public DateTime DateTime;

        public StopWatcherEvent(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public string SerializeObject()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new {
                ds_event = "StopWatcherEvent",
                dt_event = DateTime.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }
}
