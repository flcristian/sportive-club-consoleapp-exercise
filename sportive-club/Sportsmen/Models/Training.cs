namespace sportive_club.Sportsmen.Models;

public class Training(string title, float powerLevelGain)
{
    public string Title { get; set; } = title;
    public float PowerLevelGain { get; set; } = powerLevelGain;
}