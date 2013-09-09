using Microsoft.Practices.Unity;

using NUnit.Framework;

using Rhino.Mocks;


namespace Core.Tests.EventLogListenerTests
{
    [TestFixture]
    public abstract class Given_health_monitor : TestBase
    {
        protected IHealthMonitor healthMonitor;

        protected void GivenIHaveEventProvider()
        {
            var eventProvider = MockRepository.GenerateMock<IEventProvider>();
            this.Container.RegisterInstance(typeof(IEventProvider), eventProvider);
        }

        protected void GivenIHaveEventValidator()
        {
            var eventsValidator = MockRepository.GenerateMock<IEventValidator>();
            this.Container.RegisterInstance(typeof(IEventValidator), eventsValidator);
        }

        protected void GivenIHavePoolManager()
        {
            var poolManager = MockRepository.GenerateMock<IPoolManager>();
            this.Container.RegisterInstance(typeof(IPoolManager), poolManager);
        }

        protected void GivenIHaveHealthMonitor()
        {
            this.Container.RegisterType<IHealthMonitor, HealthMonitor>();
            this.healthMonitor = this.Container.Resolve<IHealthMonitor>();
        }
    }
}
