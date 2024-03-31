using Medicine.Models;
using Newtonsoft.Json;
using sportive_club.Medicine.Repository.Interfaces;
using sportive_club.Sportsmen.Models;
using sportive_club.System.Constants;

namespace sportive_club.Medicine.Repository;

public class MedicineRepository : IMedicineRepository
{
    private List<BannedMedicine> _list;

    public MedicineRepository()
    {
        string jsonText = File.ReadAllText(Paths.MEDICINE_DATA_PATH);
        _list = JsonConvert.DeserializeObject<List<BannedMedicine>>(jsonText)!;
    }
    
    public List<BannedMedicine> GetAll()
    {
        return _list;
    }

    public List<BannedMedicine> GetByType(SportsmanType type)
    {
        return _list.Where(m => m.Type == type).ToList();
    }
    
    public BannedMedicine? GetByNameAndType(string name, SportsmanType type)
    {
        return _list.FirstOrDefault(m => m.Name.Equals(name) && m.Type == type);
    }

    public BannedMedicine? GetByName(string name)
    {
        return _list.FirstOrDefault(m => m.Name.Equals(name));
    }

    public void Create(BannedMedicine bannedMedicine)
    {
        _list.Add(bannedMedicine);
        SaveAll();
    }

    public void DeleteByName(string name)
    {
        BannedMedicine bannedMedicine = GetByName(name)!;
        _list.Remove(bannedMedicine);
        SaveAll();
    }

    public void Delete(BannedMedicine medicine)
    {
        _list.Remove(medicine);
        SaveAll();
    }
    
    public void SaveAll()
    {
        string jsonText = JsonConvert.SerializeObject(_list, Formatting.Indented);
        File.WriteAllText(Paths.MEDICINE_DATA_PATH, jsonText);
    }
}