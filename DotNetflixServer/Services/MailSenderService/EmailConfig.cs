namespace Services.MailSenderService
{
	public class EmailConfig
	{
		public string FromName { get; set; }
		public string FromAddress { get; set; }
		public string FromPassword { get; set; }

		public string MailServerAddress { get; set; }
		public int MailServerPort { get; set; }
		public bool EnableSsl { get; set; }
	}
}
