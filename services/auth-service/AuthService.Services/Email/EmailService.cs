using AuthService.Application.Abstractions.Services;
using AuthService.Application.Helpers.Email;
using AuthService.Domain.Commons;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Net;

namespace AuthService.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task<Response<string>> SendEmailAsync(EmailMessage emailMessage, CancellationToken cancellationToken)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromAddress));
                message.To.Add(MailboxAddress.Parse(emailMessage.To));
                message.Subject = emailMessage.Subject;

                message.Body = new TextPart(emailMessage.IsHtml ? TextFormat.Html : TextFormat.Plain)
                {
                    Text = emailMessage.Content
                };

                using var smtp = new SmtpClient();

                try
                {
                    await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, SecureSocketOptions.SslOnConnect);
                    await smtp.AuthenticateAsync(_emailSettings.FromAddress, _emailSettings.Password);
                    await smtp.SendAsync(message);
                }
                finally
                {
                    if (smtp.IsConnected)
                        await smtp.DisconnectAsync(true, cancellationToken);
                }

                return Response<string>.Success("Email sent successfully");
            }
            catch (SmtpCommandException ex) when (ex.ErrorCode == SmtpErrorCode.RecipientNotAccepted)
            {
                return Response<string>.Fail($"Invalid recipient address: {emailMessage.To}", HttpStatusCode.BadRequest);
            }
            catch (AuthenticationException)
            {
                return Response<string>.Fail("Authentication failed: invalid username or password", HttpStatusCode.Unauthorized);
            }
            catch (ServiceNotConnectedException)
            {
                return Response<string>.Fail("SMTP server is not reachable", HttpStatusCode.ServiceUnavailable);
            }
            catch (ServiceNotAuthenticatedException)
            {
                return Response<string>.Fail("SMTP authentication required", HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                return Response<string>.Fail($"Error sending email: {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
    }
}
