namespace sportive_club.System.Exceptions;

public class ItemsDoNotExist : Exception
{
    public ItemsDoNotExist(string? message) : base(message)
    {
    }
}