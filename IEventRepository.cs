namespace MonitoramentoTempoOcioso
{
    interface IEventRepository
    {
        void Add(IEvent @event);
        int Count();
    }
}
