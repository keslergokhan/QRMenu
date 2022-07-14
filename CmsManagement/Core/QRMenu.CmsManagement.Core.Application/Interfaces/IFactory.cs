using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Interfaces
{
    public interface IFactory<T> where T : new()
    {
        public T Get();

        #region Custom
        public LoggerAddComman LoggerAddComman();
        #endregion
    }
}
