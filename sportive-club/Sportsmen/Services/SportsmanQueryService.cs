using sportive_club.Sportsmen.Models;
using sportive_club.Sportsmen.Repository;
using sportive_club.Sportsmen.Repository.Interfaces;
using sportive_club.Sportsmen.Services.Interfaces;
using sportive_club.System.Constants;
using sportive_club.System.Exceptions;

namespace sportive_club.Sportsmen.Services;

public class SportsmanQueryService : ISportsmanQueryService
{
    private ISportsmenRepository _repository;

    public SportsmanQueryService()
    {
        _repository = SportsmenRepositorySingleton.Instance;
    }

    public List<Sportsman> GetAllSportsmen()
    {
        List<Sportsman> sportsmen = _repository.GetAll();

        if (sportsmen.Count == 0)
        {
            throw new ItemsDoNotExist(ExceptionMessages.SPORTSMEN_DO_NOT_EXIST);
        }

        return sportsmen;
    }

    public Sportsman GetSportsmanByName(string name)
    {
        Sportsman? sportsman = _repository.GetByName(name);

        if (sportsman == null)
        {
            throw new ItemDoesNotExist(ExceptionMessages.SPORTSMAN_DOES_NOT_EXIST);
        }

        return sportsman;
    }
    
    public Sportsman GetSportsmanById(int id)
    {
        Sportsman? sportsman = _repository.GetById(id);

        if (sportsman == null)
        {
            throw new ItemDoesNotExist(ExceptionMessages.SPORTSMAN_DOES_NOT_EXIST);
        }

        return sportsman;
    }
}