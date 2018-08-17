using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Standard.Controllers.Responses
{
    public class ErrorsInfo
    {
        public ErrorsInfo(ModelStateDictionary fields, IEnumerable<string> messages)
        {
          this.Messages = messages;
          Fields = new List<Field>();

          foreach (var field in fields)
          {
            if (field.Value.ValidationState != ModelValidationState.Valid)
            {
              Fields.Add(new Field(field.Key.ToString(), field.Value.Errors));
            }
          }
        }

        public IEnumerable<string> Messages { get; set; }
        public IList<Field> Fields { get; set; }
    }
}