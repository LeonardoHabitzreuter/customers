using System;
using CrossCutting.ValueObjects;
using Domain.Entities;

namespace Tests.Builders
{
    public class CustomerBuilder
    {
        private string _name = "skol";
        private CPF _cpf = new CPFBuilder().Build();
        private DateTime _birthDate = DateTime.Now.AddYears(-18);

        public Customer Build()
        {
          return new Customer(_name, _cpf, _birthDate, null);
        }
    }
}