using System;

namespace CrossCutting.Mediator
{
    public abstract class Event : DomainMessage
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}