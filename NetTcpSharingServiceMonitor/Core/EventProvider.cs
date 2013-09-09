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
        private EventLog eventLog;

        public event Action<object, EntryWrittenEventArgs> OnEntryWritten;

        public EventProvider()
        {
            this.eventLog = new EventLog { Log = "System" };
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
