namespace Services.Infrastructure.EmailService;

public interface IEmailService
{
	public Task SendEmailAsync(string email, string subject, string message);
}
