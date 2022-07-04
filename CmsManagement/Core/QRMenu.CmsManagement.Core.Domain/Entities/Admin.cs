using QRMenu.CmsManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Domain.Entities
{
    /// <summary>
    ///     Kullanıcı
    /// </summary>
    public class Admin : BaseEntity
    {
        /// <summary>
        /// Kullanıcı Adı
        /// </summary>
        [Required]
        [Display(Name="Ad")]
        [StringLength(100,ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string AdminName { get; set; }
        /// <summary>
        ///     Kullanıcı Soyadı
        /// </summary>
        [Required]
        [Display(Name = "Soyad")]
        [StringLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir !")]
        public string AdminSurName { get; set; }
        /// <summary>
        ///     Kullanıcı e-posta
        /// </summary>
        [Required]
        [Display(Name = "Eposta")]
        [MaxLength(150, ErrorMessage = "{0} en fazla {1} karakter olabilir !"),MinLength(5,ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string AdminEmail { get; set; }
        /// <summary>
        ///     Kullanıcı profil
        /// </summary>
        [Display(Name = "Profil")]
        [MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(5, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string? AdminAvatar { get; set; }
        [Required]
        [Display(Name = "Şifre")]
        [MaxLength(18, ErrorMessage = "{0} en fazla {1} karakter olabilir !"), MinLength(6, ErrorMessage = "{0} en az {1} karakter olabilir !")]
        public string AdminPassword { get; set; }


        #region ICollection
        /// <summary>
        ///     Adminin şirketleri
        /// </summary>
        public ICollection<Company> Companies { get; set; }
        #endregion

    }
}
