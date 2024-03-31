using Medicine.Models;
using sportive_club.Medicine.Services;
using sportive_club.Sportsmen.Models;
using sportive_club.Sportsmen.Services;
using sportive_club.System.Exceptions;

namespace sportive_club.Controllers;

public class SportiveClubController
{
    private SportsmanQueryService _sportsmanQueryService;
    private SportsmanCommandService _sportsmanCommandService;
    private MedicineCommandService _medicineCommandService;
    private bool _running;

    public SportiveClubController()
    {
        _sportsmanQueryService = SportsmanQueryServiceSingleton.Instance;
        _sportsmanCommandService = SportsmanCommandServiceSingleton.Instance;
        _medicineCommandService = MedicineCommandServiceSingleton.Instance;

        Run();
    }

    private void Run()
    {
        _running = true;

        while (_running)
        {
            DisplayOptions();
            string input = Console.ReadLine()!;

            DisplaySpacing();
            
            switch (input)
            {
                case "1":
                    AddSportsman();
                    break;
                case "2":
                    RemoveSportsman();
                    break;
                case "3":
                    BanMedicine();
                    break;
                case "4":
                    UnbanMedicine();
                    break;
                case "5":
                    AddTraining();
                    break;
                case "6":
                    RemoveTraining();
                    break;
                case "7":
                    ExecuteTraining();
                    break;
                case "8":
                    SeeAllSportsmen();
                    break;
                case "9":
                    SeeSportsman();
                    break;
                default:
                    _running = false;
                    break;
            }
            
            DisplaySpacing();
        }
    }

    // MESSAGES

    private void DisplayOptions()
    {
        string message = "Choose what you want to do:\n";
        message += "1. Add a new sportsman\n";
        message += "2. Remove a sportsman\n";
        message += "3. Ban medicine\n";
        message += "4. Unban medicine\n";
        message += "5. Add training to sportsman\n";
        message += "6. Remove training from sportsman\n";
        message += "7. Execute training for sportsman\n";
        message += "8. See details of all sportsmen\n";
        message += "9. See details of a sportsman\n";
        message += "Anything else to close\n";

        Console.Write(message);
    }

    private void DisplaySpacing()
    {
        Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
    }

    // METHODS

    private void AddSportsman()
    {
        Console.Write("Enter the name of the sportsman: ");
        string name = Console.ReadLine()!;
        Console.WriteLine("Sportsman types: Football, Handball, Tennis, Basketball");
        Console.WriteLine("Enter the type of the sportsman: ");
        string typeString = Console.ReadLine()!;
        SportsmanType type;

        if (!Enum.TryParse(typeString, out type))
        {
            Console.WriteLine("Invalid sportsman type value!");
            return;
        }

        Sportsman sportsman = new Sportsman(-1, name, new List<Training>(), new List<string>(), type);

        try
        {
            _sportsmanCommandService.CreateSportsman(sportsman);
        }
        catch (ItemAlreadyExists ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void RemoveSportsman()
    {
        Console.Write("Enter the name of the sportsman: ");
        string name = Console.ReadLine()!;

        try
        {
            _sportsmanCommandService.DeleteSportsmanByName(name);
        }
        catch (ItemDoesNotExist ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void BanMedicine()
    {
        Console.Write("Enter the name of the medicine: ");
        string name = Console.ReadLine()!;
        Console.WriteLine("Sportsman types: Football, Handball, Tennis, Basketball");
        Console.WriteLine("Enter the sportsmen type: ");
        string typeString = Console.ReadLine()!;
        SportsmanType type;

        if (!Enum.TryParse(typeString, out type))
        {
            Console.WriteLine("Invalid sportsman type value!");
            return;
        }

        BannedMedicine medicine = new BannedMedicine(type, name);

        try
        {
            _medicineCommandService.BanMedicine(medicine);
        }
        catch (ItemAlreadyExists ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void UnbanMedicine()
    {
        Console.Write("Enter the name of the medicine: ");
        string name = Console.ReadLine()!;
        Console.WriteLine("Sportsman types: Football, Handball, Tennis, Basketball");
        Console.WriteLine("Enter the sportsmen type: ");
        string typeString = Console.ReadLine()!;
        SportsmanType type;
        
        if (!Enum.TryParse(typeString, out type))
        {
            Console.WriteLine("Invalid sportsman type value!");
            return;
        }

        BannedMedicine medicine = new BannedMedicine(type, name);
            
        try
        {
            _medicineCommandService.BanMedicine(medicine);
        }
        catch (ItemDoesNotExist ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void AddTraining()
    {
        
    }

    private void RemoveTraining()
    {
        
    }

    private void ExecuteTraining()
    {
        
    }

    private void SeeAllSportsmen()
    {
        
    }

    private void SeeSportsman()
    {
        
    }
}