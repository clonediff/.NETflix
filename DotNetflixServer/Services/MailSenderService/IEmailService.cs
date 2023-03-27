namespace Services.MailSenderService
{
	public interface IEmailService
	{
		public Task SendEmailAsync(string email, string subject, string message);
	}
}
