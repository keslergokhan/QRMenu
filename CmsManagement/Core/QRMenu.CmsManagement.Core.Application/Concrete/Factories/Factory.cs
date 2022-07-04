using QRMenu.CmsManagement.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Concrete.Factories
{
    public static class Factory<T> where T : new()
    {
        public static IFactory<T> Init()
        {
            return new FactoryBase<T>();
        }
    }
}
