using MediatR;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Handlers
{
    public class AdminGetHandler : IRequestHandler<AdminGetQuery, IResultData<AdminReadDto>>
    {
        private readonly IReadRepository<Domain.Entities.Admin> _readRepository;
        public AdminGetHandler(IReadRepository<Domain.Entities.Admin> readRepository)
        {
            this._readRepository = readRepository;
        }

        public async Task<IResultData<AdminReadDto>> Handle(AdminGetQuery request, CancellationToken cancellationToken)
        {
            var result = await _readRepository.GetFindIdAsync(request.Id);
            AdminReadDto admind = new AdminReadDto
            {
                AdminAvatar = result.Data.AdminAvatar,
                AdminEmail = result.Data.AdminEmail,
                AdminName = result.Data.AdminName
            };

            return new ResultData<AdminReadDto>().SetDataSuccessMessage(admind, result.Message);
        }
    }
}
