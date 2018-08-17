using System;
using System.Collections.Generic;

namespace CrossCutting.Base
{
    public abstract class Entity : ErrorBase
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            SetId(Guid.NewGuid());
        }

        public void SetId(Guid id) => Id = id;
    }
}