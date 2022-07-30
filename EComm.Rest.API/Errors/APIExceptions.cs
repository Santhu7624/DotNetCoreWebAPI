using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Rest.API.Errors
{
    public class APIExceptions : APIResponse
    {
        public APIExceptions(int statusCode, string meassage = null, string details =null) 
        : base(statusCode, meassage)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}