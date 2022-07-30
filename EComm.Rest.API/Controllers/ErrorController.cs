using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Rest.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EComm.Rest.API.Controllers
{

    [ApiController]
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new APIResponse(code));
        }                
    }
}