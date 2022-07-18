using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
using QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries;
using QRMenu.CmsManagement.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Concrete.Factories
{
    public class FactoryBase<T> : IFactory<T> where T : new()
    {
        private T _value;

        public FactoryBase()
        {
            this.Create();
        }

        private void Create()
        {
            var method = typeof(FactoryBase<T>).GetMethod(typeof(T).Name.ToString());
            this._value = (T)method.Invoke(this, null);
        }

        public T Get()
        {
            return this._value;
        }



        #region Custom
        public LoggerAddComman LoggerAddComman()
        {
            return new LoggerAddComman();
        }

        public AdminGetQuery AdminGetQuery()
        {
            return new AdminGetQuery();
        }
        #endregion


    }
}
