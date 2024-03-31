using Newtonsoft.Json;
using sportive_club.Sportsmen.Models;
using sportive_club.Sportsmen.Repository.Interfaces;
using sportive_club.System.Constants;

namespace sportive_club.Sportsmen.Repository;

public class SportsmenRepository : ISportsmenRepository
{
    private List<Sportsman> _list;

    public SportsmenRepository()
    {
        string jsonText = File.ReadAllText(Paths.SPORTSMEN_DATA_PATH);
        _list = JsonConvert.DeserializeObject<List<Sportsman>>(jsonText)!;
    }
    
    public List<Sportsman> GetAll()
    {
        return _list;
    }

    public List<Sportsman> GetByType(SportsmanType type)
    {
        return _list.Where(s => s.Type == type).ToList();
    }

    public Sportsman? GetByName(string name)
    {
        return _list.FirstOrDefault(s => s.Name == name);
    }
    
    public Sportsman? GetById(int id)
    {
        return _list.FirstOrDefault(s => s.Id == id);
    }

    public void Create(Sportsman sportsman)
    {
        sportsman.Id = NewId();
        _list.Add(sportsman);
        SaveAll();
    }

    public void Update(Sportsman sportsman)
    {
        Sportsman old = GetById(sportsman.Id)!;
        _list.Remove(old);
        _list.Add(sportsman);
        SaveAll();
    }

    public void DeleteById(int id)
    {
        Sportsman sportsman = GetById(id)!;
        _list.Remove(sportsman);
        SaveAll();
    }

    public void DeleteByName(string name)
    {
        Sportsman sportsman = GetByName(name)!;
        _list.Remove(sportsman);
        SaveAll();
    }

    public void SaveAll()
    {
        string jsonText = JsonConvert.SerializeObject(_list, Formatting.Indented);
        File.WriteAllText(Paths.SPORTSMEN_DATA_PATH, jsonText);
    }
    
    // PRIVATE METHODS
    
    private int NewId()
    {
        Random random = new Random();
        int id = random.Next(1, 1000);

        while (GetById(id) != null)
        {
            id = random.Next(1, 1000);
        }

        return id;
    }
}