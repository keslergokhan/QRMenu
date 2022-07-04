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
    public class Product : BaseEntity
    {
        /// <summary>
        ///     Required,max(250),min(2)<br></br>
        ///     Ürün adı
        /// </summary>
        [Required]
        [Display(Name = "Ürün adı")]
        [MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(2, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string ProductName { get; set; }
        /// <summary>
        ///     MaxLength(1500)<br></br>
        ///     Ürün açıklama
        /// </summary>
        [Display(Name = "Ürün Açıklama")]
        [MaxLength(1500, ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string Description { get; set; }
        /// <summary>
        ///     Ürün fiyat
        /// </summary>
        [Display(Name = "Ürün Fiyat")]
        public decimal Price { get; set; }
        /// <summary>
        ///     max(150)<br></br>
        ///     Ürün Resim
        /// </summary>
        [Display(Name = "Ürün Resim")]
        [MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string Image { get; set; }

        #region ForeignKey
        /// <summary>
        ///     Dil
        /// </summary>
        public Guid? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        #endregion

        #region ICollection
        /// <summary>
        ///     Ürünün kategorileri N-N
        /// </summary>
        public ICollection<CategoryProducts> CategoryProducts { get; set; }
        #endregion
    }
}
