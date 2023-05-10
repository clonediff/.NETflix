using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace Services.Infrastructure.EmailService
{
	public class EmailService : IEmailService
	{
		private readonly EmailConfig ec;

		public EmailService(IOptions<EmailConfig> emailConfig)
		{
			ec = emailConfig.Value;
		}

		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var mailFrom = new MailAddress(ec.FromAddress, ec.FromName);
			var mailTo = new MailAddress(email);

			var emailMessage = new MailMessage(mailFrom, mailTo);

			emailMessage.Subject = subject;
			emailMessage.Body = message;
			emailMessage.IsBodyHtml = true;

			var smtp = new SmtpClient(ec.MailServerAddress, ec.MailServerPort);
			smtp.Credentials = new NetworkCredential(ec.FromAddress, ec.FromPassword);
			smtp.EnableSsl = ec.EnableSsl;

			await smtp.SendMailAsync(emailMessage);
		}
	}
}
