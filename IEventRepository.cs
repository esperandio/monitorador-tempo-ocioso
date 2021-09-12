namespace MonitoramentoTempoOcioso
{
    interface IEventRepository
    {
        void Add(IdleTimeEvent idleEvent);
        int Count();
    }
}
