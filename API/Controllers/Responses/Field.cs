using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Standard.Controllers.Responses
{
    public class Field
    {
      public Field(string name, ModelErrorCollection messages)
      {
          Name = name;
          Messages = new List<string>();
          
          foreach (var error in messages)
          {
              Messages.Add(error.ErrorMessage);
          }
      }

      public string Name { get; set; }
      public IList<string> Messages { get; set; }
    }
}