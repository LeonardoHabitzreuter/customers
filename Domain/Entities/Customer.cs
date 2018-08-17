using System;
using System.Collections.Generic;
using CrossCutting.Base;
using CrossCutting.ValueObjects;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer(){}
        
        public Customer(string name, CPF cpf, DateTime birthDate, params PhoneNumber[] phoneNumbers)
        {
            SetName(name);
        }

        public string Name { get; private set; }
        
        private void SetName(string name)
        {
          Name = name;
        }

        public override IList<string> Validate()
        {
          return new List<string>();
        }
    }
}