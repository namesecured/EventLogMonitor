namespace Core
{
    public interface ISettings
    {
        long EventId { get; set; }

        string TaskCategory { get; set; }

        string Source { get; set; }

        string Description { get; set; }
    }
}