namespace MonitoramentoTempoOcioso.Interfaces.Events
{
    interface IEventRepository
    {
        void Add(IEvent @event);
        int Count();
    }
}
