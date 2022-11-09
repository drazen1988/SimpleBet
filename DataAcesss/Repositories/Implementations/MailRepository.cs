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

        public async Task<bool> NotifyUserAsync(string userName, string password, string firstName, string email, string clanName)
        {
            // Build email
            var mail = new MimeMessage();
            mail.Sender = MailboxAddress.Parse(_smtpSettings.Value.SenderEmail);
            mail.From.Add(MailboxAddress.Parse(_smtpSettings.Value.SenderEmail));
            mail.To.Add(MailboxAddress.Parse(email));
            mail.Subject = "SimpleBet - kreiran login";

            var builder = new BodyBuilder();

            builder.TextBody = "\nDragi/a " + firstName + ",\n\nU nastavku maila naći ćeš pristupne podatke za aplikaciju SimpleBet.\n\nKorisničko ime: " + userName + 
                               "\nLozinka: " + password + "\nKlan: " + clanName + "\nLink na aplikaciju: www.simple-apps.info" + "\n\nSavjetujemo ti da nakon prve prijave u aplikaciju promijeniš lozinku." +
                               "\n\nZahvaljujemo na sudjelovanju i želimo ti dobru zabavu! Sretno!" + "\n\nOvo je automatska poruka i nemoj odgovarati na nju.";

            mail.Body = builder.ToMessageBody();

            // Send email
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.MessageSent += (sender, args) =>
                { };
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await smtp.ConnectAsync(_smtpSettings.Value.Server, _smtpSettings.Value.Port, true);
                await smtp.AuthenticateAsync(_smtpSettings.Value.UserName, _smtpSettings.Value.Password);
                await smtp.SendAsync(mail);
                await smtp.DisconnectAsync(true);
            }

            return true;
        }

        public async Task<bool> SendFeedbackAsync(string feedbackTypeText, string description, string userName, string fullName)
        {
            // Build email
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_smtpSettings.Value.SenderEmail);
            email.From.Add(MailboxAddress.Parse(_smtpSettings.Value.SenderEmail));
            email.To.Add(MailboxAddress.Parse("info@simple-apps.info"));
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

        public async Task<bool> SendResetPasswordAsync(string userName, string password, string firstName, string email)
        {
            // Build email
            var mail = new MimeMessage();
            mail.Sender = MailboxAddress.Parse(_smtpSettings.Value.SenderEmail);
            mail.From.Add(MailboxAddress.Parse(_smtpSettings.Value.SenderEmail));
            mail.To.Add(MailboxAddress.Parse(email));
            mail.Subject = "SimpleBet - resetirana lozinka";

            var builder = new BodyBuilder();

            builder.TextBody = "\nDragi/a " + firstName + ",\n\nResetirana ti je lozinka za prijavu u SimpleBet aplikaciju. Tvoji novi login podaci su sljedeći.\n\nKorisničko ime: " + userName +
                               "\nLozinka: " + password + "\nLink na aplikaciju: www.simple-apps.info" + "\n\nSavjetujemo ti da nakon prve prijave u aplikaciju promijeniš lozinku." +
                               "\n\nOvo je automatska poruka i nemoj odgovarati na nju.";

            mail.Body = builder.ToMessageBody();

            // Send email
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.MessageSent += (sender, args) =>
                { };
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await smtp.ConnectAsync(_smtpSettings.Value.Server, _smtpSettings.Value.Port, true);
                await smtp.AuthenticateAsync(_smtpSettings.Value.UserName, _smtpSettings.Value.Password);
                await smtp.SendAsync(mail);
                await smtp.DisconnectAsync(true);
            }

            return true;
        }
    }
}
