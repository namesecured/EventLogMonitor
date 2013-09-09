using System;
using System.Diagnostics;

using Microsoft.Practices.Unity;

using NUnit.Framework;

using Rhino.Mocks;

using TestStack.BDDfy;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;

namespace Core.Tests.EventLogListenerTests
{
    [TestFixture]
    [Story(AsA = "As a health monitor", IWant = "I want to be able to reset pool when expected event has come.", SoThat = "So pool should be restarted.")]
    public class When_expected_event_comes : Given_health_monitor
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
                .When(_ => this.WhenExpectedEventComes())
                .Then(_ => this.ThenPollShouldBeRestarted())
                .BDDfy();
        }

        private void GivenExpectedEvent()
        {
            var eventsValidator = this.Container.Resolve<IEventValidator>();
            eventsValidator.Stub(x => x.IsEventExpected(Arg<EntryWrittenEventArgs>.Is.Anything)).Repeat.Any().Return(true);
        }

        private void GivenExpectedPoolManagerBehaviour()
        {
            var poolManager = MockRepository.GenerateMock<IPoolManager>();
            poolManager.Expect(x => x.Reset()).Repeat.Once();
        }

        private void WhenExpectedEventComes()
        {
            var eventsProvider = this.Container.Resolve<IEventProvider>();
            eventsProvider.Raise(x => x.OnEntryWritten += null, eventsProvider, Arg<EntryWrittenEventArgs>.Is.Anything);
        }

        private void ThenPollShouldBeRestarted()
        {
            var poolManager = this.Container.Resolve<IPoolManager>();
            poolManager.VerifyAllExpectations();
        }
    }
}
