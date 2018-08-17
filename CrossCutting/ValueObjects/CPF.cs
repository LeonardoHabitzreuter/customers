using System.Collections.Generic;
using CrossCutting.Base;

namespace CrossCutting.ValueObjects
{
    public class CPF : ErrorBase
    {
      public CPF(string cpf)
      {
        Value = cpf;
      }

      public string Value { get; private set; }

      public override IList<string> Validate()
      {
        return new List<string>();
      }
    }
}