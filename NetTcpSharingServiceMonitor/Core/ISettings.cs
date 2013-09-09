using System.Diagnostics;

namespace Core
{
    public interface ISettings
    {
        long EventId { get; }

        string Source { get; }

        string Description { get; }

        EventLogEntryType Level { get; }
    }
}