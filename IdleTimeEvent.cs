using System;

namespace MonitoramentoTempoOcioso
{
    struct IdleTimeEvent
    {
        public DateTime DateTime;
        public uint MillisecondsIdle;

        public IdleTimeEvent(DateTime dateTime, uint millisecondsIdle)
        {
            DateTime = dateTime;
            MillisecondsIdle = millisecondsIdle;
        }
    }
}
