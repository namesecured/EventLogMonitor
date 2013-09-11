using System;
using System.Diagnostics;

namespace Core
{
    public class EventValidator :IEventValidator
    {
        private readonly ISettings settings;

        public EventValidator(ISettings settings)
        {
            this.settings = settings;
        }

        public bool IsEventExpected(EntryWrittenEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException("eventArgs");
            }
            
            if (!eventArgs.Entry.EntryType.Equals(this.settings.Level))
            {
                return false;
            }

            if (!eventArgs.Entry.Source.Contains(this.settings.Source))
            {
                return false;
            }

            if (!eventArgs.Entry.Message.Contains(this.settings.Description))
            {
                return false;
            }

            return true;
        }
    }
}
