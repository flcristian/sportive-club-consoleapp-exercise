using sportive_club.Sportsmen.Models;

namespace sportive_club.Sportsmen.Services.Interfaces;

public interface ISportsmanQueryService
{
    List<Sportsman> GetAllSportsmen();
    Sportsman GetSportsmanById(int id);
    Sportsman GetSportsmanByName(string name);
}