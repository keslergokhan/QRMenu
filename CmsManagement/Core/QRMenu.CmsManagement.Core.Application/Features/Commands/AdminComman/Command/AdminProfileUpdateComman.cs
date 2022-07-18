using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command
{
    public class AdminProfileUpdateComman :IRequest<IResult>
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
        ///     Admin şifre
        /// </summary>
        public string AdminPassword { get; set; }
        /// <summary>
        ///     Admin güncellenmek istenen yeni şifre
        /// </summary>
        public string AdminPasswordNew { get; set; }
        /// <summary>
        ///     Admin güncellenmek istenen yeni şifre kontrol
        /// </summary>
        public string adminPasswordNewControl { get; set; }
    }
}
