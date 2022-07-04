using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command
{
    public class AdminRegisterComman : IRequest<IResultData<Guid>>
    {
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
        /// <summary>
        ///     Kullanıcı Şifre
        /// </summary>
        public string AdminPassword { get; set; }
        /// <summary>
        /// Admin şifre kontrolu
        /// </summary>
        public string AdminPasswordControl { get; set; }
    }
}
