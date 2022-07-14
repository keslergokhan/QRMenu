using MediatR;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command
{
    public class LoggerAddComman : IRequest<IResult>
    {
        public string LoggerTitle { get; set; }
        /// <summary>
        ///     Hata açıklama
        /// </summary>
        public string? LoggerDescription { get; set; }
        /// <summary>
        ///     Hata konumu (Method/Controller)
        /// </summary>
        public string ErrorLocation { get; set; }
        /// <summary>
        ///     Exception.Message değeri
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        ///     Exception tipi
        /// </summary>
        public string? ExceptionType { get; set; }

        public LoggerAddComman setLoggerTitle(string loggerTitle)
        {
            this.LoggerTitle = loggerTitle;
            return this;
        }

        public LoggerAddComman setLoggerDescription(string loggerDescription)
        {
            this.LoggerDescription = loggerDescription;
            return this;
        }

        public LoggerAddComman setErrorMessage(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            return this;
        }

        public LoggerAddComman setErrorLocation(string errorLocation)
        {
            this.ErrorLocation = errorLocation;
            return this;
        }

        public LoggerAddComman setExceptionType(string exceptionType)
        {
            this.ExceptionType = exceptionType;
            return this;
        }
    }
}
