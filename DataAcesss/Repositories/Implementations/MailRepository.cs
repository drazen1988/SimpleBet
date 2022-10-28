using DataAcesss.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using Models.Helpers;

namespace DataAcesss.Repositories.Implementations
{
    public class MailRepository : IMailRepository
    {
        private readonly IOptions<SmtpSettings> _smtpSettings;

        public MailRepository(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }

        public async Task<bool> SendFeedbackAsync(string feedbackTypeText, string description, string userName, string fullName)
        {
            // Build email
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_smtpSettings.Value.SenderEmail);
            email.From.Add(MailboxAddress.Parse(_smtpSettings.Value.SenderEmail));
            email.To.Add(MailboxAddress.Parse("info@simple-apps.hr"));
            email.Subject = "SimpleBet feedback - " + feedbackTypeText;

            var builder = new BodyBuilder();

            builder.TextBody = "\nOpis prijedloga:\n" + description + "\n\nKorisnik: " + userName + "(" + fullName + ")";

            email.Body = builder.ToMessageBody();

            // Send email
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.MessageSent += (sender, args) =>
                { };
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await smtp.ConnectAsync(_smtpSettings.Value.Server, _smtpSettings.Value.Port, true);
                await smtp.AuthenticateAsync(_smtpSettings.Value.UserName, _smtpSettings.Value.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }

            return true;
        }
    }
}
