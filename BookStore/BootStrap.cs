using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace BookStore
{
    public static class BootStrap
    {
        public static void Initialize()
        {
            DependencyResolver.RegisterResolver(BuildContainer());
        }

        private static IUnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            // Essential part, register service type to be used by controllers.
            container.RegisterType<IBookService, PhysicalBookService>();
        }
    }

    public static class DependencyResolver
    {
        // Concurrency issue not enforced for testing purpose.

        private static IUnityContainer _container;

        public static void RegisterResolver(IUnityContainer container)
        {
            _container = container;
        }

        public static T Resolve<T>()
        {
            var obj = _container.Resolve<T>();
            return obj;
        }
    }
}
