using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Rest.API.Errors
{
    public class APIValidationResponse : APIResponse
    {
        public APIValidationResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors {get; set;}
    }
}