using AutoMapper;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using QRMenu.CmsManagement.Core.Application.Concrete.Factories;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
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
        private readonly IMapper _mapper;
        private readonly IReadRepository<Domain.Entities.Admin> _readRepository;
        private readonly IMediator _mediator;

        public AdminGetHandler(IReadRepository<Domain.Entities.Admin> readRepository, IMediator mediator, IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task<IResultData<AdminReadDto>> Handle(AdminGetQuery request, CancellationToken cancellationToken)
        {
            IResultData<AdminReadDto> result = new ResultData<AdminReadDto>();
            try
            {
                var getResult = await _readRepository.GetFindIdAsync(request.Id);
                return result.SetDataSuccessMessage(_mapper.Map<AdminReadDto>(getResult.Data), result.Message);
            }
            catch (Exception ex)
            {
                await _mediator.Send(Factory<LoggerAddComman>.Init().Get()
                   .setLoggerTitle("Admin Kayıt Getir")
                   .setLoggerDescription("Admin bilgilerini sorgulama aşamasında teknik bir problem yaşandı")
                   .setErrorLocation("AdminGetHandler | " + typeof(AdminGetHandler).Assembly.Location)
                   .setExceptionType(ex.GetType().ToString())
                   .setErrorMessage(ex.Message));
                return result.SetDataSuccessMessage(null, GlobalMessage.globalError);
            }

            
        }
    }
}
