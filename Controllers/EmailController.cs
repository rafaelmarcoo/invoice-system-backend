using invoice_system_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice_system_backend.Controllers
{  
    [ApiController]
    [Route("apli/[controller")]
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] Email email)
        {
            await _emailService.SendEmailAsync(email.To, email.Subject, email.Body);

            return Ok("Email sent successfully");
        }
    }
}
