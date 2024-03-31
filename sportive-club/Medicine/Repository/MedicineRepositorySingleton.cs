namespace sportive_club.Medicine.Repository;

public class MedicineRepositorySingleton
{
    private static readonly Lazy<MedicineRepository> _instance = new(() => new MedicineRepository());

    public static MedicineRepository Instance => _instance.Value;

    private MedicineRepositorySingleton() { }
}