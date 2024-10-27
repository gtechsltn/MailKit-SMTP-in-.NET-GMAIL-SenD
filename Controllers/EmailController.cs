using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GmailWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(string recipientEmail, string recipientName)
        {
            string subject = "Test Email from ASP.NET Core";
            string body = "Hello, this is a test email sent using MailKit in ASP.NET Core!";

            await _emailService.SendEmailAsync(recipientEmail, recipientName, subject, body);

            return Ok("Email sent successfully");
        }
    }
}
