namespace Domain.Entities;

public class UserChatMessage
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;
    public DateTime SendingDate { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}