using QRMenu.CmsManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Domain.Entities
{
    public class Logger : BaseEntity
    {
        /// <summary>
        ///     Hata başlık
        /// </summary>
        [MaxLength(250)]
        [Required]
        public string LoggerTitle { get; set; }
        /// <summary>
        ///     Hata açıklama
        /// </summary>
        [MaxLength(550)]
        public string? LoggerDescription { get; set; }
        /// <summary>
        ///     Hata konumu (Method/Controller)
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string ErrorLocation { get; set; }
        /// <summary>
        ///     Exception.Message değeri
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        ///     Exception tipi
        /// </summary>
        [MaxLength(250)]
        public string? ExceptionType { get; set; }
    }
}
