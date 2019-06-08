using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GUI.Providers
{
    class UnityServiceLocator : IService
    {
        private UnityContainer container;

        public UnityServiceLocator()
        {
            container = new UnityContainer();
        }

        void IService.Register<TInterface, TImplementation>()
        {
            container.RegisterType<TInterface, TImplementation>();
        }

        TInterface IService.Get<TInterface>()
        {
            return container.Resolve<TInterface>();
        }
    }
}
