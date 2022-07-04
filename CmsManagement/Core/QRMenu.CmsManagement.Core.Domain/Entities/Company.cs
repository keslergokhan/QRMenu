using QRMenu.CmsManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Domain.Entities
{
    /// <summary>
    ///     Şirket
    /// </summary>
    public class Company : BaseEntity
    {
        /// <summary>
        ///     Şirket adı
        /// </summary>
        [Required]
        [Display(Name = "Şirket Adı")]
        [MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(5, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string CompanyName { get; set; }
        /// <summary>
        ///     Şirket hakkında
        /// </summary>
        [Display(Name = "Hakkımızda")]
        public string CompanyAbout { get; set; }
        /// <summary>
        ///     Şirket logo
        /// </summary>
        [Display(Name = "Şirket Logo")]
        [MaxLength(50,ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string CompanyLogo { get; set; }
        

        #region FreignKey
        /// <summary>
        ///     Şirket sahibi
        /// </summary>
        public Guid AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        /// <summary>
        ///     Dil
        /// </summary>
        public Guid? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        #endregion

        #region ICollection
        /// <summary>
        ///     Şirket şubeleri
        /// </summary>
        public ICollection<Branch> Branches { get; set; }
        #endregion

    }
}
