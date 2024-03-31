using Medicine.Models;
using sportive_club.Sportsmen.Models;

namespace sportive_club.Medicine.Repository.Interfaces;

public interface IMedicineRepository
{
    List<BannedMedicine> GetAll();
    List<BannedMedicine> GetByType(SportsmanType type);
    BannedMedicine? GetByNameAndType(string name, SportsmanType type);
    BannedMedicine? GetByName(string name);
    void Create(BannedMedicine medicine);
    void DeleteByName(string name);
    void Delete(BannedMedicine medicine);
    void SaveAll();
}