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
    }
}
