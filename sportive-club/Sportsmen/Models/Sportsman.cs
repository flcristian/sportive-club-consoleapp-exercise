namespace sportive_club.Sportsmen.Models;

public class Sportsman : ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Training> Trainings { get; set; }
    public List<string> BannedMedicine { get; set; }
    public SportsmanType Type { get; set; }
    
    public Sportsman(int id, string name, List<Training> trainings, List<string> bannedMedicine, SportsmanType type)
    {
        Id = id;
        Name = name;
        Trainings = trainings;
        BannedMedicine = bannedMedicine;
        Type = type;
    }

    public object Clone()
    {
        return new Sportsman(Id, Name, Trainings, BannedMedicine, Type);
    }

    public void ExecuteTraining(string title)
    {
        Console.Write($"Sportsman {Name} ");

        Training? training = Trainings.Find(t => t.Title.Equals(title));
        
        if (training == null)
        {
            Console.WriteLine($"doesn't have that training.");
            return;
        }
        
        Console.WriteLine($"executed training " + title);
    }

    public float GetPowerLevel()
    {
        return Trainings.Sum(training => training.PowerLevelGain);
    }
}