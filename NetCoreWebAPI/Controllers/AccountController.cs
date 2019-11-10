using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPI.Operations;
using static NetCoreWebAPI.Operations.Parameters.RequestParameters;

namespace NetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("Login")]
        public ActionResult<string> Login(LoginRequest request)
        {
            return Ok(AccountOperations.Login(request.email, request.password));
        }

   

    }
}
