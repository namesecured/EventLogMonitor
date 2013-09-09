using System;

using Microsoft.Practices.Unity;

using NUnit.Framework;

using Rhino.Mocks;

using TestStack.BDDfy;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;

namespace Core.Tests.EventLogListenerTests
{
    [TestFixture]
    [Story(AsA = "As a health monitor", IWant = "I want to be skip al unknown events.", SoThat = "So pool shouldn't be restarted.")]
    public class When_unexpected_event_comes : Given_health_monitor
    {
        [Test]
        public void Run()
        {
            this.Given(_ => this.GivenIHaveEventProvider())
                .And(_ => this.GivenIHaveEventValidator())
                .And(_ => this.GivenIHavePoolManager())
                .And(_ => this.GivenIHaveHealthMonitor())
                .And(_ => this.GivenExpectedEvent())
                .And(_ => this.GivenExpectedPoolManagerBehaviour())
                .When(_ => this.WhenUnexpectedEventComes())
                .Then(_ => this.ThenNothingToDo())
                .BDDfy();
        }

        private void GivenExpectedEvent()
        {
            var eventsValidator = this.Container.Resolve<IEventValidator>();
            eventsValidator.Stub(x => x.IsEventExpected(Arg<EventArgs>.Is.Anything)).Repeat.Any().Return(true);
        }

        private void GivenExpectedPoolManagerBehaviour()
        {
            var poolManager = MockRepository.GenerateMock<IPoolManager>();
            poolManager.Expect(x => x.Reset()).Repeat.Never();
        }

        private void WhenUnexpectedEventComes()
        {
            var eventsProvider = this.Container.Resolve<IEventProvider>();
            eventsProvider.Raise(x => x.OnEntryWritten += null, eventsProvider, EventArgs.Empty);
        }

        private void ThenNothingToDo()
        {
            var poolManager = MockRepository.GenerateMock<IPoolManager>();
            poolManager.VerifyAllExpectations();
        }
    }
}
