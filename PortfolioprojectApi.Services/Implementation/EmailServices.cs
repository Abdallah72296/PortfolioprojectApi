using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using PortfolioProject.Data.Helpers;
using PortfolioProject.Services.Abstract;

namespace PortfolioProject.Services.Implementation
{
    public class EmailServices : IEmailServices
    {
        #region Fields
        private readonly EmailSettings _emailSettings;
        #endregion
        #region Constructors
        public EmailServices(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        #endregion
        #region Handle Functions
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                using var client = new SmtpClient();
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.Auto);
                client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);

                var bodyBuilder = new BodyBuilder { HtmlBody = body, TextBody = "Confirm your account." };

                var message = new MimeMessage
                {
                    Body = bodyBuilder.ToMessageBody(),
                    Subject = subject
                };

                message.From.Add(new MailboxAddress("Portfolio Team", _emailSettings.FromEmail));
                message.To.Add(new MailboxAddress("", toEmail));

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // رمي استثناء لتسجيل فشل الإرسال في الـ Handler
                throw new ApplicationException($"Failed to send email to {toEmail}: {ex.Message}", ex);
            }
        }
        #endregion
    }
}
