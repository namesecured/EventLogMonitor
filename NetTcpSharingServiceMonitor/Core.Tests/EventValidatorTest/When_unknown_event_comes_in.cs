using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Rhino.Mocks;

using TestStack.BDDfy;

namespace Core.Tests.EventValidatorTest
{
    [TestFixture]
    public class When_unknown_event_comes_in : Given_event_validator
    {
        private EntryWrittenEventArgs entryWrittenEventArgs;

        private bool result;

        [Test]
        public void Run()
        {
            this.BDDfy();
        }

        private void GivenUnknownEvent()
        {
            var entry = MockRepository.GenerateStub<EventLogEntry>();
            var settings = new Settings();

            entry.Stub(x => x.InstanceId).Repeat.Any().Return(int.MaxValue);
            entry.Stub(x => x.Source).Repeat.Any().Return(settings.Source);
            entry.Stub(x => x.Message).Repeat.Any().Return(settings.Description);
            entry.Stub(x => x.EntryType).Repeat.Any().Return(EventLogEntryType.Error);

            this.entryWrittenEventArgs = new EntryWrittenEventArgs(entry);
        }

        private void WhenValidateEvent()
        {
            this.result = this.EventValidator.IsEventExpected(this.entryWrittenEventArgs);
        }

        private void ThenResultShouldBeFalse()
        {
            this.result.Should().BeFalse();
        }
    }
}
