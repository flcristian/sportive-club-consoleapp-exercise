using sportive_club.Sportsmen.Models;

namespace Medicine.Models;

public class BannedMedicine(SportsmanType type, string name)
{
    public SportsmanType Type { get; set; } = type;
    public string Name { get; set; } = name;
}