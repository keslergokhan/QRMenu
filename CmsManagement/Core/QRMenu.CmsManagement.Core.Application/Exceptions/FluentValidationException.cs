using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Exceptions
{
    public class FluentValidationException : Exception
    {
        public IResult result { get; set; }
        public FluentValidationException():base()
        {
        }
        public FluentValidationException(string message):base(message)
        {
        }
        public FluentValidationException(IResult result):base(result.ErrorMessage)
        {
            this.result = result;
        }

        public void bubirdeneme()
        {

        }
        
    }
}
