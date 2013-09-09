using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Settings : ISettings
    {
        public Settings()
        {
            this.EventId = 8;
            this.TaskCategory = "Sharing Service";
            this.Source = "SMSvcHost";
            this.Description = "An error occurred while dispatching a duplicated socket: this handle is now leaked in the process.";
            this.Level = EventLogEntryType.Error;
        }

        public long EventId { get; set; }

        public string TaskCategory { get; set; }

        public string Source { get; set; }

        public string Description { get; set; }

        public EventLogEntryType Level { get; set; }
    }
}
