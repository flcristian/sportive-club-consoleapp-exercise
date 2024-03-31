namespace sportive_club.System.Exceptions;

public class ItemDoesNotExist : Exception
{
    public ItemDoesNotExist(string? message) : base(message)
    {
    }
}