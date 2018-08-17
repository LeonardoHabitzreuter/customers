using System;
using FluentValidation.Results;

namespace CrossCutting.Mediator
{
    public abstract class Command : DomainMessage
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}