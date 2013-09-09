using System;
using System.Configuration;
using System.Diagnostics;

namespace Core
{
    public class Settings : ISettings
    {
        public long EventId
        {
            get
            {
                return long.Parse(ConfigurationManager.AppSettings["EventId"]);
            }
        }

        public string Source
        {
            get
            {
                return ConfigurationManager.AppSettings["Source"];
            }
        }

        public string Description
        {
            get
            {
                return ConfigurationManager.AppSettings["Description"];
            }
        }

        public EventLogEntryType Level
        {
            get
            {
                return (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), ConfigurationManager.AppSettings["Level"]);
            }
        }
    }
}
