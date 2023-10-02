namespace Domain.Entities;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;
    public DateTime SendingDate { get; set; }
    public bool IsRead { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}
