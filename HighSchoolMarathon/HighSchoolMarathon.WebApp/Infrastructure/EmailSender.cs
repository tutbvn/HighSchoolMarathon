using HighSchoolMarathon.WebApp.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System.Threading.Tasks;

namespace HighSchoolMarathon.WebApp.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings emailSettings;

        public EmailSender(EmailSettings _emailSettings)
        {
            this.emailSettings = _emailSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(emailSettings.From, emailSettings.From));

            var mailAddresses = email.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var mailAddress in mailAddresses)
            {
                mailMessage.To.Add(new MailboxAddress("email", mailAddress.Trim()));
            }

            mailMessage.Subject = subject;
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(emailSettings.SmtpServer, emailSettings.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(emailSettings.UserName, emailSettings.Password);

                    await client.SendAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    /// logger.LogError(ex.Message);
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
