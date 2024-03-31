namespace sportive_club.Sportsmen.Repository;

public class SportsmenRepositorySingleton
{
    private static readonly Lazy<SportsmenRepository> _instance = new(() => new SportsmenRepository());

    public static SportsmenRepository Instance => _instance.Value;

    private SportsmenRepositorySingleton() { }
}