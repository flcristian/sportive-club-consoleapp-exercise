using Medicine.Models;
using sportive_club.System.Constants;
using sportive_club.System.Exceptions;

namespace sportive_club.Sportsmen.Models;

public class Sportsman : ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Trainings { get; set; }
    public List<string> BannedMedicine { get; set; }
    public SportsmanType Type { get; set; }
    
    public Sportsman(int id, string name, List<string> trainings, List<string> bannedMedicine, SportsmanType type)
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
        if (!Trainings.Contains(title))
        {
            throw new ItemDoesNotExist(ExceptionMessages.TRAINING_DOES_NOT_EXIST);
        }
        
        Console.WriteLine($"Sportsman {Name} executed training " + title);
    }

    public float GetPowerLevel()
    {
        return Trainings.Count * 5;
    }

    public override string ToString()
    {
        string desc = "";
        desc += $"Name: {Name}\n";
        desc += $"Type: {Type}\n";
        desc += "\nTrainings:\n";
        foreach (string training in Trainings)
        {
            desc += training + "\n";
        }

        desc += "\nBanned medicine:\n";
        foreach (string medicine in BannedMedicine)
        {
            desc += medicine + "\n";
        }

        desc += $"\nPower Level: {GetPowerLevel()}\n";

        return desc;
    }
}