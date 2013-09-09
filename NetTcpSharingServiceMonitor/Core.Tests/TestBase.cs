using Microsoft.Practices.Unity;

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
            this.Container.RegisterType<ISettings, SettingsStub>();
        }
    }
}
