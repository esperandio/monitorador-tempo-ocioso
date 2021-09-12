using System.Collections.Generic;

namespace MonitoradorTempoOcioso
{
    class InMemoryEventRepository : IEventRepository
    {
        private readonly List<IdleTimeEvent> _idleEvents;

        public InMemoryEventRepository()
        {
            _idleEvents = new List<IdleTimeEvent>();
        }

        public void Add(IdleTimeEvent idleEvent)
        {
            _idleEvents.Add(idleEvent);
        }

        public int Count()
        {
            return _idleEvents.Count;
        }
    }
}
