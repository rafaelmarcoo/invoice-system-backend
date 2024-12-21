using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace invoice_system_backend.Controllers
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var emailSettings = _config.GetSection("EmailSettings");

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Your App Name", emailSettings["SenderEmail"]));
            email.To.Add(new MailboxAddress("", to));
            email.Subject = subject;

            email.Body = new TextPart("html")
            {
                Text = body
            };

            using(var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(emailSettings["SMTPServer"], int.Parse(emailSettings["Port"]), MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(emailSettings["SenderEmail"], emailSettings["SenderPassword"]);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
