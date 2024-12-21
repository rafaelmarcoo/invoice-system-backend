using invoice_system_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice_system_backend.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromForm] Email email)
        {
            byte[] fileBytes = null;
            if(email.File != null)
            {
                using(var memoryStream = new MemoryStream())
                {
                    await email.File.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
            }

            await _emailService.SendEmailAsync(
                email.To,
                email.Subject,
                email.Body,
                fileBytes,
                email.FileName);

            return Ok("Email sent successfully");
        }
    }
}
