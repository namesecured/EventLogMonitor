using System.Diagnostics;

using FluentAssertions;

using Microsoft.Practices.Unity;

using NUnit.Framework;

using Rhino.Mocks;

using TestStack.BDDfy;

namespace Core.Tests.EventValidatorTest
{
    [TestFixture]
    public class When_known_event_comes_in : Given_event_validator
    {
        private EntryWrittenEventArgs e;

        private EntryWrittenEventArgs entryWrittenEventArgs;

        private bool result;

        [Test]
        public void Run()
        {
            this.BDDfy();
        }

        private void GivenKnownEvent()
        {
            var entry = MockRepository.GenerateStub<EventLogEntry>();
            var settings = this.Container.Resolve<ISettings>();

            entry.Stub(x => x.EventID).Repeat.Any().Return(settings.EventId);
            entry.Stub(x => x.Source).Repeat.Any().Return(settings.Source);
            entry.Stub(x => x.Message).Repeat.Any().Return(settings.Description);
            entry.Stub(x => x.EntryType).Repeat.Any().Return(settings.Level);

            this.entryWrittenEventArgs = new EntryWrittenEventArgs(entry);
        }

        private void WhenValidateEvent()
        {
            this.result = this.EventValidator.IsEventExpected(this.entryWrittenEventArgs);
        }

        private void ThenResultShuldBeTrue()
        {
            this.result.Should().BeTrue();
        }
    }
}
