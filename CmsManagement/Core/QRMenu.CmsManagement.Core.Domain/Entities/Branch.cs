using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRMenu.CmsManagement.Core.Domain.Common;

namespace QRMenu.CmsManagement.Core.Domain.Entities
{
    /// <summary>
    ///     Şirket Şubesi
    /// </summary>
    public class Branch : BaseEntity
    {
        /// <summary>
        ///     Şube adı
        /// </summary>
        [Required]
        [Display(Name = "Şube Adı")]
        [MaxLength(120, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string BranchName { get; set; }
        /// <summary>
        ///     Şube hakkında açıklama 
        /// </summary>
        [Display(Name = "Şube Hakkında")]
        public string BranchAbout { get; set; }
        /// <summary>
        ///     Şubenin adresi
        /// </summary>
        [Required]
        [Display(Name = "Şube Adresi")]
        [MaxLength(500, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string BranchAddres { get; set; }
        /// <summary>
        ///     Şube Telefon
        /// </summary>
        [Required]
        [Display(Name = "Şube Telefon")]
        [MaxLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(5, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string BranchPhone { get; set; }
        /// <summary>
        ///     Şube Email adresi
        /// </summary>
        [Required]
        [Display(Name = "Email Adresi")]
        [MaxLength(120, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(4, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string BranchEmail { get; set; }
        /// <summary>
        ///     Şube çalışan sayısı
        /// </summary>
        public short BranchEmployeeCount { get; set; }
        /// <summary>
        ///     Şube harita konumu google/yandex
        /// </summary>
        [Display(Name = "Harita Konumu")]
        public string BrancheMapRoute { get; set; }


        #region ForeingKey
        /// <summary>
        ///     Şubnin şirketi
        /// </summary>
        /// 
        public Guid CompanyId { get; set; }
        [ForeignKey("CampanyId")]
        public Company Company { get; set; }
        /// <summary>
        ///     Dil
        /// </summary>
        public Guid? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        #endregion

    }
}
