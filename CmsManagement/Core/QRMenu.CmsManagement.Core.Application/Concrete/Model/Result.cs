using QRMenu.CmsManagement.Core.Application.Enums;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Concrete.Model
{
    public class Result : IResult
    {
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public ResultStatusEnum Status { get; set; } = ResultStatusEnum.Success;
        public Exception Exception { get; set; }

        public IResult SetWarningMessage(string message)
        {
            this.Message = message;
            this.Status = ResultStatusEnum.Warning;
            return this;
        }

        public IResult SetSuccessMessage(string errorMessage)
        {
            this.Message = errorMessage;
            this.Status = ResultStatusEnum.Success;
            return this;
        }

        public IResult SetErrorMessage(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Status = ResultStatusEnum.Error;
            return this;
        }

        public IResult SetException(Exception exception)
        {
            this.Exception = exception;
            return this;
        }

        public IResult ClearException()
        {
            this.Exception = null;
            return this;
        }
    }
}
