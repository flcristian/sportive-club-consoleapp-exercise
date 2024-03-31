namespace sportive_club.Sportsmen.Services;

public class SportsmanCommandServiceSingleton
{
    private static readonly Lazy<SportsmanCommandService> _instance = new(() => new SportsmanCommandService());

    public static SportsmanCommandService Instance => _instance.Value;

    private SportsmanCommandServiceSingleton() { }
}