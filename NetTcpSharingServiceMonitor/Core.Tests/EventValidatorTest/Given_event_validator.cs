using Microsoft.Practices.Unity;

using NUnit.Framework;

namespace Core.Tests.EventValidatorTest
{
    [TestFixture]
    public abstract class Given_event_validator : TestBase
    {
        public IEventValidator EventValidator { get; set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            this.EventValidator = new EventValidator(this.Container.Resolve<ISettings>());
        }
    }
}
