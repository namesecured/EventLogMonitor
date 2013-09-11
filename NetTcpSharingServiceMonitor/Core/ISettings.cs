using System.Diagnostics;

namespace Core
{
    public interface ISettings
    {
        string Log { get; }

        string Source { get; }

        string Description { get; }

        EventLogEntryType Level { get; }

        void Initialize();
    }
}