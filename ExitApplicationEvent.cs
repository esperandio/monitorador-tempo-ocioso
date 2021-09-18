﻿using System;

namespace MonitoramentoTempoOcioso
{
    struct ExitApplicationEvent : IEvent
    {
        public DateTime DateTime;

        public ExitApplicationEvent(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public string SerializeObject()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                ds_event = "ExitApplicationEvent",
                dt_event = DateTime.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }
}
