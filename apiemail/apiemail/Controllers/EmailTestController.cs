using apiemail.Data;
using apiemail.Models;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace apiemail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTestController : ControllerBase
    {
        private readonly EmailDbContext _context;

        public EmailTestController(EmailDbContext context)
        {
            _context = context;
        }

        [HttpPost("send")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendMail(EmailModel emailModel)
        {

            MailAddress address = new MailAddress("email address");
            MailAddress target = new MailAddress(emailModel.TargetEmail);

            await _context.Emails.AddAsync(emailModel);

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(address.Address, "password"),
                EnableSsl = true
            };

            MailMessage message = new MailMessage(address,target);
            message.Sender = address;
            message.Subject = emailModel.Subject;
            message.Body = emailModel.Body;

            client.Send(message);

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
