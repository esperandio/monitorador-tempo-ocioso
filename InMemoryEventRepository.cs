using System.Collections.Generic;

namespace MonitoramentoTempoOcioso
{
    class InMemoryEventRepository : IEventRepository
    {
        private readonly List<IEvent> _events;

        public InMemoryEventRepository()
        {
            _events = new List<IEvent>();
        }

        public void Add(IEvent @event)
        {
            _events.Add(@event);
        }

        public int Count()
        {
            return _events.Count;
        }
    }
}
