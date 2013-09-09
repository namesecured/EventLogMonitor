using System.Collections.Generic;
using System.Diagnostics;

namespace Core
{
    public interface ISettings
    {
        List<int> AppPoolIds { get; set; }

        long EventId { get; set; }

        string TaskCategory { get; set; }

        string Source { get; set; }

        string Description { get; set; }

        EventLogEntryType Level { get; set; }
    }
}