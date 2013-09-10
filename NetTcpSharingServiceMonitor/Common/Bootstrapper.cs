using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Common
{
    public static class Bootstrapper
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.LoadConfiguration();
            return container;
        }
    }
}
