using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Rest.API.Errors
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string meassage = null)
        {
            StatusCode = statusCode;
            Meassage = meassage ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }

        public string Meassage { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request you have made",
                401 => "Authorized, You are not",
                404 => "Resource found, it was not",
                500 => "Server Error",
                _ => null
            };
        }


    }
}