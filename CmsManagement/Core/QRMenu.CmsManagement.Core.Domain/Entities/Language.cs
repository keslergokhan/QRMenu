using QRMenu.CmsManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Domain.Entities
{
    /// <summary>
    ///     Çoklu dil tablosu
    /// </summary>
    public class Language : BaseEntity
    {
        /// <summary>
        ///     Dil adı
        /// </summary>
        [Required]
        [Display(Name = "Dil Adı")]
        [MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string LanguageName { get; set; }
        /// <summary>
        ///     Dil kodu
        /// </summary>
        [Required]
        [Display(Name = "Dil kod")]
        [MaxLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string LanguageCode { get; set; }
        /// <summary>
        ///     Dil Bayrak iconu
        /// </summary>
        [Display(Name = "Bayrak")]
        [MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string LanguageFlag { get; set; }
        /// <summary>
        ///     Sıralama
        /// </summary>
        [Display(Name = "Sıra")]
        public int Sorting { get; set; }
    }
}
