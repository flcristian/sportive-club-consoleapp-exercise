using Medicine.Models;
using sportive_club.Medicine.Repository;
using sportive_club.Medicine.Repository.Interfaces;
using sportive_club.Medicine.Services.Interfaces;
using sportive_club.Sportsmen.Models;
using sportive_club.Sportsmen.Repository;
using sportive_club.Sportsmen.Repository.Interfaces;
using sportive_club.System.Constants;
using sportive_club.System.Exceptions;

namespace sportive_club.Medicine.Services;

public class MedicineCommandService : IMedicineCommandService
{
    private IMedicineRepository _medicineRepository;
    private ISportsmenRepository _sportsmenRepository;

    public MedicineCommandService()
    {
        _medicineRepository = MedicineRepositorySingleton.Instance;
        _sportsmenRepository = SportsmenRepositorySingleton.Instance;
    }

    public void BanMedicine(BannedMedicine medicine)
    {
        if (_medicineRepository.GetByName(medicine.Name) != null)
        {
            throw new ItemAlreadyExists(ExceptionMessages.MEDICINE_ALREADY_EXISTS);
        } 
        
        _medicineRepository.Create(medicine);
        
        foreach (Sportsman sportsman in _sportsmenRepository.GetByType(medicine.Type))
        {
            sportsman.BannedMedicine.Add(medicine.Name);
        }

        _sportsmenRepository.SaveAll();
    }

    public void UnbanMedicine(string name)
    {
        BannedMedicine? medicine = _medicineRepository.GetByName(name);
        
        if (medicine == null)
        {
            throw new ItemDoesNotExist(ExceptionMessages.MEDICINE_DOES_NOT_EXIST);
        }

        foreach (Sportsman sportsman in _sportsmenRepository.GetByType(medicine.Type))
        {
            sportsman.BannedMedicine.Remove(medicine.Name);
        }
        
        _sportsmenRepository.SaveAll();
        
        _medicineRepository.DeleteByName(name);
    }

    public void UnbanMedicine(BannedMedicine medicine)
    {
        if (_medicineRepository.GetByNameAndType(medicine.Name, medicine.Type) == null)
        {
            throw new ItemDoesNotExist(ExceptionMessages.MEDICINE_DOES_NOT_EXIST);
        }

        foreach (Sportsman sportsman in _sportsmenRepository.GetByType(medicine.Type))
        {
            sportsman.BannedMedicine.Remove(medicine.Name);
        }
        
        _sportsmenRepository.SaveAll();
        
        _medicineRepository.Delete(medicine);
    }
}