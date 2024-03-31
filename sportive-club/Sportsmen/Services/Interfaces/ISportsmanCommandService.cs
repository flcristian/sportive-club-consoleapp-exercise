using sportive_club.Sportsmen.Models;

namespace sportive_club.Sportsmen.Services.Interfaces;

public interface ISportsmanCommandService
{
    void CreateSportsman(Sportsman sportsman);
    void UpdateSportsman(Sportsman sportsman);
    void DeleteSportsmanById(int id);
    void DeleteSportsmanByName(string name);
}