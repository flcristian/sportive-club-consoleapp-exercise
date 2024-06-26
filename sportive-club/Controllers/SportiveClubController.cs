using Medicine.Models;
using sportive_club.Medicine.Services;
using sportive_club.Sportsmen.Models;
using sportive_club.Sportsmen.Services;
using sportive_club.System.Constants;
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

        Sportsman sportsman = new Sportsman(-1, name, new List<string>(), new List<string>(), type);

        try
        {
            _sportsmanCommandService.CreateSportsman(sportsman);
            Console.WriteLine(ControllerMessages.ADDED_SPORTSMAN);
        }
        catch (ItemAlreadyExists ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        DisplaySpacing();
    }

    private void RemoveSportsman()
    {
        Console.Write("Enter the name of the sportsman: ");
        string name = Console.ReadLine()!;

        try
        {
            _sportsmanCommandService.DeleteSportsmanByName(name);
            Console.WriteLine(ControllerMessages.REMOVED_SPORTSMAN);
        }
        catch (ItemDoesNotExist ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        DisplaySpacing();
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
            Console.WriteLine(ControllerMessages.BANNED_MEDICINE);
        }
        catch (ItemAlreadyExists ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        DisplaySpacing();
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
            _medicineCommandService.UnbanMedicine(medicine);
            Console.WriteLine(ControllerMessages.UNBANNED_MEDICINE);
        }
        catch (ItemDoesNotExist ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        DisplaySpacing();
    }

    private void AddTraining()
    {
        Console.Write("Enter the name of the sportsman: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter the title of the training: ");
        string title = Console.ReadLine()!;

        try
        {
            _sportsmanCommandService.AddTraining(name, title);
            Console.WriteLine(ControllerMessages.ADDED_TRAINING);
        }
        catch (ItemDoesNotExist ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ItemAlreadyExists ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        DisplaySpacing();
    }

    private void RemoveTraining()
    {
        Console.Write("Enter the name of the sportsman: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter the title of the training: ");
        string title = Console.ReadLine()!;

        try
        {
            _sportsmanCommandService.RemoveTraining(name, title);
            Console.WriteLine(ControllerMessages.REMOVED_TRAINING);
        }
        catch (ItemDoesNotExist ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        DisplaySpacing();
    }

    private void ExecuteTraining()
    {
        Console.Write("Enter the name of the sportsman: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter the title of the training: ");
        string title = Console.ReadLine()!;

        try
        {
            _sportsmanCommandService.ExecuteTraining(name, title);
        }
        catch (ItemDoesNotExist ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        DisplaySpacing();
    }

    private void SeeAllSportsmen()
    {
        try
        {
            foreach (Sportsman sportsman in _sportsmanQueryService.GetAllSportsmen())
            {
                Console.Write(sportsman);
                DisplaySpacing();
            }
        }
        catch (ItemsDoNotExist ex)
        {
            Console.WriteLine(ex.Message);
            DisplaySpacing();
        }
    }

    private void SeeSportsman()
    {
        Console.Write("Enter the name of the sportsman: ");
        string name = Console.ReadLine()!;
        
        try
        {
            Console.WriteLine(_sportsmanQueryService.GetSportsmanByName(name));
        }
        catch (ItemDoesNotExist ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        DisplaySpacing();
    }
}