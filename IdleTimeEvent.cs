using System;

namespace MonitoradorTempoOcioso
{
    struct IdleTimeEvent
    {
        public DateTime DateTime;
        public uint SecondsIdle;

        public IdleTimeEvent(DateTime dateTime, uint secondsIdle)
        {
            DateTime = dateTime;
            SecondsIdle = secondsIdle;
        }
    }
}
