using System.Collections.Generic;

namespace MonitoramentoTempoOcioso.Interfaces.Events
{
    public interface IEventRepository
    {
        void Add(IEvent @event);
        int Count();
        List<IEvent> GetEventsToSync();
    }
}
