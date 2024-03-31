using Medicine.Models;
using sportive_club.Medicine.Repository;
using sportive_club.Medicine.Repository.Interfaces;
using sportive_club.Sportsmen.Models;
using sportive_club.Sportsmen.Repository;
using sportive_club.Sportsmen.Repository.Interfaces;
using sportive_club.Sportsmen.Services.Interfaces;
using sportive_club.System.Constants;
using sportive_club.System.Exceptions;

namespace sportive_club.Sportsmen.Services;

public class SportsmanCommandService : ISportsmanCommandService
{
    private ISportsmenRepository _sportsmenRepository;
    private IMedicineRepository _medicineRepository;

    public SportsmanCommandService()
    {
        _sportsmenRepository = SportsmenRepositorySingleton.Instance;
        _medicineRepository = MedicineRepositorySingleton.Instance;
    }

    public void CreateSportsman(Sportsman sportsman)
    {
        if (_sportsmenRepository.GetByName(sportsman.Name) != null)
        {
            throw new ItemAlreadyExists(ExceptionMessages.SPORTSMAN_ALREADY_EXISTS);
        }
        
        foreach (BannedMedicine medicine in _medicineRepository.GetByType(sportsman.Type))
        {
            sportsman.BannedMedicine.Add(medicine.Name);
        }
        
        _sportsmenRepository.Create(sportsman);
    }

    public void UpdateSportsman(Sportsman sportsman)
    {
        if (_sportsmenRepository.GetByName(sportsman.Name) != null)
        {
            throw new ItemAlreadyExists(ExceptionMessages.SPORTSMAN_ALREADY_EXISTS);
        }
        
        Sportsman? old = _sportsmenRepository.GetById(sportsman.Id);
        
        if (old == null)
        {
            throw new ItemDoesNotExist(ExceptionMessages.SPORTSMAN_DOES_NOT_EXIST);
        }

        sportsman.BannedMedicine = old.BannedMedicine;
        _sportsmenRepository.Update(sportsman);
    }

    public void DeleteSportsmanById(int id)
    {
        if (_sportsmenRepository.GetById(id) == null)
        {
            throw new ItemDoesNotExist(ExceptionMessages.SPORTSMAN_DOES_NOT_EXIST);
        }
        
        _sportsmenRepository.DeleteById(id);
    }

    public void DeleteSportsmanByName(string name)
    {
        if (_sportsmenRepository.GetByName(name) == null)
        {
            throw new ItemDoesNotExist(ExceptionMessages.SPORTSMAN_DOES_NOT_EXIST);
        }
        
        _sportsmenRepository.DeleteByName(name);
    }
}