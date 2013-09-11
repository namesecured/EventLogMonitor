using System;
using System.Configuration;
using System.Diagnostics;

namespace Core
{
    public class Settings : ISettings
    {
        private const string LogAppKey = "Log";
        
        private const string SourceAppKey = "Source";

        private const string DescriptionAppKey = "Description";

        private const string LevelAppKey = "Level";

        public string Log { get; private set; }

        public string Source { get; private set; }

        public string Description { get; private set; }

        public EventLogEntryType Level { get; private set; }

        public void Initialize()
        {
            this.InitializeLog();
            this.InitializeSource();
            this.InitializeDescription();
            this.InitializeLevel();
        }

        private void InitializeLog()
        {
            var value = this.GetAppSettingsValue(LogAppKey);
            this.Log = value;
        }

        private void InitializeSource()
        {
            var value = this.GetAppSettingsValue(SourceAppKey);
            this.Source = value;
        }

        private void InitializeDescription()
        {
            var value = this.GetAppSettingsValue(DescriptionAppKey);
            this.Description = value;
        }

        private void InitializeLevel()
        {
            var value = this.GetAppSettingsValue(LevelAppKey);
            this.Level = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), value);
        }

        private string GetAppSettingsValue(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            this.ValidateAppSettingsValue(key, value);
            return value;
        }

        private void ValidateAppSettingsValue(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var message = string.Format("{0} isn't set.", key);
            throw new ConfigurationErrorsException(message);
        }
    }
}
