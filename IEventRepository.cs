namespace MonitoradorTempoOcioso
{
    interface IEventRepository
    {
        void Add(IdleTimeEvent idleEvent);
        int Count();
    }
}
