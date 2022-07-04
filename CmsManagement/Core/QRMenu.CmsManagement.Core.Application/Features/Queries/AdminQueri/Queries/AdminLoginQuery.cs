using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;

namespace QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries
{
    public class AdminLoginQuery : IRequest<IResultData<AdminReadDto>>
    {
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
    }
}
