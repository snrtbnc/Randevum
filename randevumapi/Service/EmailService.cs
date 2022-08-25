using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using randevumapi.Objects.SettingsModel;
using RandevumAPI.Interface;

namespace randevumapi.Service
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public async Task<bool> SendEmail(string email, string subject, string message)
        {
            using (var client = new SmtpClient(_smtpSettings.Server))
            {

                client.Port = _smtpSettings.Port;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                client.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
                client.EnableSsl = true;



                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_smtpSettings.FromAddress);
                mailMessage.To.Add(email);
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;
                client.Send(mailMessage);
            }
            return await Task.FromResult(true);
        }
    }
}