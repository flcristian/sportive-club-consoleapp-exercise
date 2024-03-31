using sportive_club.Sportsmen.Models;

namespace sportive_club.Sportsmen.Repository.Interfaces;

public interface ISportsmenRepository
{
    List<Sportsman> GetAll();
    List<Sportsman> GetByType(SportsmanType type);
    Sportsman? GetByName(string name);
    Sportsman? GetById(int id);
    void Create(Sportsman sportsman);
    void Update(Sportsman sportsman);
    void DeleteById(int id);
    void DeleteByName(string name);
    void SaveAll();
}