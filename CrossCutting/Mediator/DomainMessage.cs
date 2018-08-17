using MediatR;
using System;

namespace CrossCutting.Mediator
{
    public abstract class DomainMessage : INotification
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected DomainMessage()
        {
            MessageType = GetType().Name;
        }
    }
}