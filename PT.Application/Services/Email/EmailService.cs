using Microsoft.Extensions.Options;
using PT.Application.Services.Email.Models;
using PT.Application.Services.Logger;
using System.Net;
using System.Net.Mail;

namespace PT.Application.Services.Email
{
    public class EmailService
    {
        private readonly EmailSettings _settings;
        private readonly LogManagementService _logger;
        private readonly SmtpClient _smtpClient;

        public EmailService(IOptions<EmailSettings> settings, LogManagementService logger)
        {
            _settings = settings.Value;
            _logger = logger;
            _smtpClient = new SmtpClient(_settings.Host)
            {
                Port = _settings.Port,
                Credentials = new NetworkCredential(_settings.Email, _settings.Password),
                EnableSsl = true
            };
        }

        public async Task Send(EmailRequest request)
        {
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(request.From!);
                message.Subject = request.Subject;
                foreach (var to in request.To!.Split(";"))
                {
                    message.To.Add(new MailAddress(to));
                }
                if (!string.IsNullOrEmpty(request.Bcc))
                {
                    foreach (var bcc in request.Bcc!.Split(";"))
                    {
                        message.Bcc.Add(new MailAddress(bcc));
                    }
                }
                message.Body = request.Body;
                message.IsBodyHtml = true;

                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                await _logger.InsertLog(typeof(EmailService).Name, "Send", ex.Message);
            }
        }
    }
}
