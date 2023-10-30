namespace Domain.Entities;

public class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Cost { get; set; }
    public int? PeriodInDays { get; set; }
    public bool IsAvailable { get; set; }
    public List<MovieInfo> Movies { get; set; } = null!;
    public List<User> Users { get; set; } = null!;
    public List<UserSubscription> UserSubscriptions { get; set; } = null!;
    public List<SubscriptionMovieInfo> SubscriptionMovies { get; set; } = null!;
}