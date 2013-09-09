using System;

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
            this.eventProvider.OnEntryWritten += this.OnEntryWritten;
            this.eventValidator = eventValidator;
            this.poolManager = poolManager;
        }

        public void OnEntryWritten(object sender, EventArgs e)
        {
            if (!this.eventValidator.IsEventExpected(e))
            {
                return;
            }

            this.poolManager.Reset();
        }
    }
}