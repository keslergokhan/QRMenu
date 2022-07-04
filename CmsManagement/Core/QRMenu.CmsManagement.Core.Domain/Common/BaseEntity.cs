using QRMenu.CmsManagement.Core.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Domain.Common
{
    public class BaseEntity : IEntity
    {
        /// <summary>
        ///     Benzersiz id
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        ///     Oluşturulma terihi
        /// </summary>
        [Column(Order = 9997)]
        public DateTime? CreateDateAt { get; set; } = DateTime.Now;
        /// <summary>
        ///     Güncelleme tarihi
        /// </summary>
        [Column(Order = 9998)]
        public DateTime? ModifiedAt { get; set; }
        [Column(Order = 9999)]
        [DefaultValue(1)]
        public int Status { get; set; } = 1;
    }
}
