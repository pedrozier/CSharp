using EmailValidation.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmailValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTestController : ControllerBase
    {

        [HttpPost("validateEmail")]
        public bool TestEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
