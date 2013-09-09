using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.EventValidator = new EventValidator();
        }
    }
}
