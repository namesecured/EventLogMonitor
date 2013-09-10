using System.Collections.Generic;
using System.Diagnostics;

namespace Core.Tests
{
    public class SettingsStub : ISettings
    {
        public SettingsStub()
        {
        }

        public List<int> AppPoolIds { get; set; }

        public string Log { get; set; }

        public int EventId { get; set; }

        public string TaskCategory { get; set; }

        public string Source { get; set; }

        public string Description { get; set; }

        public EventLogEntryType Level { get; set; }

        public void Initialize()
        {
            this.Log = "System";
            this.EventId = 8;
            this.TaskCategory = "Sharing Service";
            this.Source = "SMSvcHost";
            this.Description = "An error occurred while dispatching a duplicated socket: this handle is now leaked in the process.";
            this.Level = EventLogEntryType.Error;
        }
    }
}
