namespace Services.Infrastructure.EmailService;

public class EmailConfig
{
	public string FromName { get; set; } = null!;
	public string FromAddress { get; set; } = null!;
	public string FromPassword { get; set; } = null!;

	public string MailServerAddress { get; set; } = null!;
	public int MailServerPort { get; set; }
}