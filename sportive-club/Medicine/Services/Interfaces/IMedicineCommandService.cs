using Medicine.Models;

namespace sportive_club.Medicine.Services.Interfaces;

public interface IMedicineCommandService
{
    void BanMedicine(BannedMedicine medicine);
    void UnbanMedicine(string name);
}