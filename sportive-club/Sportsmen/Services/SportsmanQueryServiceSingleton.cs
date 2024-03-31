namespace sportive_club.Sportsmen.Services;

public class SportsmanQueryServiceSingleton
{
    private static readonly Lazy<SportsmanQueryService> _instance = new(() => new SportsmanQueryService());

    public static SportsmanQueryService Instance => _instance.Value;

    private SportsmanQueryServiceSingleton() { }
}