using QRMenu.CmsManagement.Core.Application.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Languages
{
    public class LanguageReadDto : BaseDto
    {
        /// <summary>
        ///     Dil adı
        /// </summary>
        public string LanguageName { get; set; }
        /// <summary>
        ///     Dil kodu
        /// </summary>
        public string LanguageCode { get; set; }
        /// <summary>
        ///     Dil Bayrak iconu
        /// </summary>
        public string LanguageFlag { get; set; }
        /// <summary>
        ///     Sıralama
        /// </summary>
        public int Sorting { get; set; }
    }
}
