using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Domain.Common.Interfaces
{
    public interface IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
