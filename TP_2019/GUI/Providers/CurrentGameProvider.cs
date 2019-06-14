using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Providers
{
    class CurrentGameProvider
    {
        public static IService Instance { get; private set; }

        public static void RegisterServiceLocator(IService s)
        {
            Instance = s;
        }
    }
}
