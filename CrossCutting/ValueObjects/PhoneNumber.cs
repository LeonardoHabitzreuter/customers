using System.Collections.Generic;
using CrossCutting.Base;

namespace CrossCutting.ValueObjects
{
    public class PhoneNumber : ErrorBase
    {
        public override IList<string> Validate()
        {
          return new List<string>();
        }
    }
}