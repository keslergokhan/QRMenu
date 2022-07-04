using QRMenu.CmsManagement.Core.Domain.Common;
using QRMenu.CmsManagement.Core.Domain.Entities.Nn;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Domain.Entities
{
    public class Category : BaseEntity
    {
        /// <summary>
        ///     Required,max(250),min(2)<br></br>
        ///     Kategori Resim
        /// </summary>
        [Required]
        [Display(Name = "Kategori Ad")]
        [MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(2, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string CategoryName { get; set; }
        /// <summary>
        ///     Kategori Açıklama
        /// </summary>
        [Display(Name = "Kategori Açıklama")]
        [MaxLength(1000, ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string Description { get; set; }
        /// <summary>
        ///     Kategori Resim
        /// </summary>
        [Display(Name = "Kategori Resim")]
        [MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string Image { get; set; }

        #region ICollection
        /// <summary>
        ///     Kategorinin ürünleri N-N
        /// </summary>
        public ICollection<CategoryProducts> CategoryProducts { get; set; }
        #endregion

        #region ForeignKey
        /// <summary>
        ///     Kategori menü
        /// </summary>
        [ForeignKey("MenuId")]
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
        /// <summary>
        ///     Dil
        /// </summary>
        public Guid? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        #endregion
    }
}
