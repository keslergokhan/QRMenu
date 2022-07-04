using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin
{
    public class AdminReadDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Kullanıcı Adı
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        ///     Kullanıcı Soyadı
        /// </summary>
        public string AdminSurName { get; set; }
        /// <summary>
        ///     Kullanıcı e-posta
        /// </summary>
        public string AdminEmail { get; set; }
        /// <summary>
        ///     Kullanıcı profil
        /// </summary>
        public string AdminAvatar { get; set; }
    }
}
