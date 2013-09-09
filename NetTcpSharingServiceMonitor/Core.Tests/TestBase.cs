using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected IUnityContainer Container { get; private set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            this.Container = new UnityContainer();
        }
    }
}
