using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal class EventProvider : IEventProvider
    {
        private readonly ISettings settings;

        private EventLog eventLog;

        public event Action<object, EntryWrittenEventArgs> OnEntryWritten;

        public EventProvider(ISettings settings)
        {
            this.settings = settings;
            this.eventLog = new EventLog { Log = this.settings.Log };
            this.eventLog.EnableRaisingEvents = true;
            this.eventLog.EntryWritten += this.EventLogEntryWritten;
        }

        private void EventLogEntryWritten(object sender, EntryWrittenEventArgs e)
        {
            var handler = this.OnEntryWritten;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
