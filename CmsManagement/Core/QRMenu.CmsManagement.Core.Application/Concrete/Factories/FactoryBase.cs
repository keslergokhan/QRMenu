using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
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

        public IFactory<T> SetVale(Expression<Func<T, object>> prop, object value)
        {
            PropertyInfo propertyInfo;

            if (prop.Body is MemberExpression memberExpression)
                propertyInfo = (memberExpression.Member as PropertyInfo)!;
            else
                propertyInfo = ((((UnaryExpression)prop.Body).Operand as MemberExpression)?.Member as PropertyInfo)!;

            if (propertyInfo.PropertyType == value.GetType())
                propertyInfo.SetValue(this._value, value);
            else
                throw new Exception("Type Error");


            return this;
        }


        #region Custom
        public LoggerAddComman LoggerAddComman()
        {
            return new LoggerAddComman();
        }
        #endregion


    }
}
