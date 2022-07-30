using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Concrete.Common
{
    public class BaseDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? CreateDateAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public int Status { get; set; }
    }
}
