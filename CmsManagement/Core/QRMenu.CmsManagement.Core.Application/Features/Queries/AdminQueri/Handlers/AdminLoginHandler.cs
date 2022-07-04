using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using QRMenu.CmsManagement.Core.Application.Concrete.Factories;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
using QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Core.Domain.Entities;

namespace QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Handlers
{
    public class AdminLoginHandler : IRequestHandler<AdminLoginQuery, IResultData<AdminReadDto>>
    {
        private readonly IReadRepository<Admin> _ReadRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdminLoginHandler(IReadRepository<Admin> readRepository, IMapper mapper, IMediator mediator)
        {
            _ReadRepository = readRepository;
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<IResultData<AdminReadDto>> Handle(AdminLoginQuery request, CancellationToken cancellationToken)
        {
            IResultData<AdminReadDto> result = new ResultData<AdminReadDto>();

            try
            {
                IResultData<Admin> findResult = await _ReadRepository.Query().Where(x => x.AdminEmail == request.AdminEmail && x.AdminPassword == request.AdminPassword).FirstOrDefaultAsync();

                if (findResult.Status == Enums.ResultStatusEnum.Error)
                    return result.SetErrorMessage(findResult.ErrorMessage);

                if (findResult.Data != null)
                    result.SetDataSuccessMessage(_mapper.Map<AdminReadDto>(findResult.Data), $"{request.AdminEmail} kullanıcı mevcut");
                else
                    result.SetWarningMessage("Email adresi veya Şifre yanlış olabilir lütfen tekrar deneyin !");

            }
            catch (Exception ex)
            {
                await _mediator.Send(Factory<LoggerAddComman>.Init()
                    .SetVale(x => x.LoggerTitle, "Admin Giris")
                    .SetVale(x => x.LoggerDescription, "Admin giris, admin kimlik bilgilerinin kontrolu")
                    .SetVale(x => x.ErrorLocation, "AdminLoginHandler | " + typeof(AdminLoginHandler).Assembly.Location)
                    .SetVale(x => x.ExceptionType, ex.GetType().ToString())
                    .SetVale(x => x.ErrorMessage, ex.Message)
                    .Get()
                );
                result.SetErrorMessage(GlobalMessage.globalError).SetException(ex);
            }
            

            return result;
        }
    }
}
