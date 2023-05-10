namespace Domain.Entities;

public class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int? PeriodInDays { get; set; }
    public bool IsAvailable { get; set; }
    public List<MovieInfo> Movies { get; set; }
    public List<User> Users { get; set; }
    public List<UserSubscription> UserSubscriptions { get; set; }
    public List<SubscriptionMovieInfo> SubscriptionMovies { get; set; }
}