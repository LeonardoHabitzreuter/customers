using System.Collections.Generic;

namespace CrossCutting.Base
{
    public abstract class ErrorBase
    {
        public abstract IList<string> Validate();
    }
}