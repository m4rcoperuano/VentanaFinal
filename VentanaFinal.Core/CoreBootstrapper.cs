using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentanaFinal.Core.Interfaces;
using VentanaFinal.Core.Repositories;

namespace VentanaFinal.Core
{
    public static class CoreBootstrapper
    {
        public static void RegisterDataTypes(IUnityContainer container)
        {
            container.RegisterType<IRepository, Repository>();
        }
    }
}
