namespace sportive_club.Medicine.Services;

public class MedicineCommandServiceSingleton
{
    private static readonly Lazy<MedicineCommandService> _instance = new(() => new MedicineCommandService());

    public static MedicineCommandService Instance => _instance.Value;

    private MedicineCommandServiceSingleton() { }
}