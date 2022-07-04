using MediatR;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries
{
    public class AdminGetQuery : IRequest<IResultData<AdminReadDto>>
    {
        public Guid Id { get; set; }
    }
}
