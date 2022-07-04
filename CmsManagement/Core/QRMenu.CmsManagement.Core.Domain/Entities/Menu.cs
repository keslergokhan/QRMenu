using QRMenu.CmsManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Domain.Entities
{
    public class Menu : BaseEntity
    {
        /// <summary>
        ///     Required,max(200),min(2)<br></br>
        ///     Menü Adı
        /// </summary>
        [Required]
        [Display(Name = "Menü Adı")]
        [MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(2, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string MenuName { get; set; }
        /// <summary>
        ///     Max(1200)<br></br>
        ///     Menü açıklama
        /// </summary>
        [Display(Name = "Menü açıklama")]
        [MaxLength(1200, ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string Description { get; set; }


        #region ICollection
        /// <summary>
        ///     Menü kategorileri
        /// </summary>
        public ICollection<Category> Categories { get; set; }
        #endregion

        #region ForeignKey
        /// <summary>
        ///     Dil
        /// </summary>
        public Guid? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        #endregion
    }
}
