using QRMenu.CmsManagement.Core.Application.Enums;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Concrete.Model
{
    public class ResultData<T> : Result, IResultData<T>
    {

        public T? Data { get; set; }

        public IResultData<T> SetData(T data)
        {
            this.Data = data;
            return this;
        }


        public IResultData<T> SetDataErrorMessage(T data, string errorMessage)
        {
            this.Data = data;
            this.ErrorMessage = errorMessage;
            this.Status = ResultStatusEnum.Error;
            return this;
        }

        public IResultData<T> SetDataSuccessMessage(T data, string message)
        {
            this.Data = data;
            this.Message = message;
            this.Status = ResultStatusEnum.Success;
            return this;
        }

        public IResultData<T> SetDataWarningMessage(T data, string message)
        {
            this.Data = data;
            this.Message = message;
            this.Status = ResultStatusEnum.Warning;
            return this;
        }

        public IResultData<T> SetException(Exception exception)
        {
            this.Exception = exception;
            return this;
        }

        public IResultData<T> SetWarningMessage(string message)
        {
            this.Message = message;
            this.Status = ResultStatusEnum.Warning;
            return this;
        }

        public IResultData<T> SetSuccessMessage(string errorMessage)
        {
            this.Message = errorMessage;
            this.Status = ResultStatusEnum.Success;
            return this;
        }

        public IResultData<T> SetErrorMessage(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Status = ResultStatusEnum.Error;
            return this;
        }

        public IResultData<T> ClearException()
        {
            this.Exception = null;
            return this;
        }
    }
}
