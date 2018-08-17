using CrossCutting.ValueObjects;

namespace Tests.Builders
{
    public class CPFBuilder
    {
        private string _cpf = "05689453788";

        public CPF Build()
        {
          return new CPF(_cpf);
        }
    }
}