using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Standard.Controllers.Responses
{
    public class ErrorsResponse
    {
        public ErrorsResponse(ModelStateDictionary fields)
        {
          Error = new ErrorsInfo(fields, new List<string>());
        }

        public ErrorsResponse(IEnumerable<string> messages)
        {
          Error = new ErrorsInfo(new ModelStateDictionary(), messages);
        }

        public ErrorsInfo Error { get; set; }
    }
}