using System;
using System.Diagnostics;

namespace Core
{
    public class HealthMonitor : IHealthMonitor
    {
        private readonly IEventProvider eventProvider;

        private readonly IEventValidator eventValidator;

        private readonly IPoolManager poolManager;

        public HealthMonitor(IEventProvider eventProvider, IEventValidator eventValidator, IPoolManager poolManager)
        {
            if (eventProvider == null)
            {
                throw new ArgumentNullException("eventProvider");
            }

            if (eventValidator == null)
            {
                throw new ArgumentNullException("eventValidator");
            }

            if (poolManager == null)
            {
                throw new ArgumentNullException("poolManager");
            }

            this.eventProvider = eventProvider;
            this.eventValidator = eventValidator;
            this.poolManager = poolManager;
        }

        public void Run()
        {
            this.eventProvider.OnEntryWritten += this.OnEntryWritten;
        }

        private void OnEntryWritten(object sender, EntryWrittenEventArgs e)
        {
            try
            {
                this.OnEntryWrittenSafe(e);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void OnEntryWrittenSafe(EntryWrittenEventArgs e)
        {
            if (!this.eventValidator.IsEventExpected(e))
            {
                return;
            }

            this.poolManager.Reset();
        }
    }
}