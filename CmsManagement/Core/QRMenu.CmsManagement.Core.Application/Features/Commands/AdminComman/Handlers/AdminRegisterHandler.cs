using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Core.Domain.Entities;
using AutoMapper;
using QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Concrete.Factories;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Handlers
{
    /// <summary>
    ///     Kullanıcı kayıt ekleme
    /// </summary>
    public class AdminRegisterHandler : IRequestHandler<AdminRegisterComman, IResultData<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IWriteRepository<Admin> _adminRepository;
        private readonly IReadRepository<Admin> _readRepository;

        public AdminRegisterHandler(IWriteRepository<Admin> adminRepository, IMapper mapper, IReadRepository<Admin> readRepository, IMediator mediator)
        {
            this._adminRepository = adminRepository;
            _mapper = mapper;
            _readRepository = readRepository;
            _mediator = mediator;
        }

        public async Task<IResultData<Guid>> Handle(AdminRegisterComman request, CancellationToken cancellationToken)
        {
            IResultData<Guid> result = new ResultData<Guid>();

            try
            {
                var emailAny = await _readRepository.Query().AnyAsync(x => x.AdminEmail == request.AdminEmail);

                if (!emailAny)
                {
                    result = await this._adminRepository.AddAsync(_mapper.Map<Admin>(request));
                    this._adminRepository.Dispose();
                }
                else
                {

                    
                    result = new ResultData<Guid>().SetWarningMessage($"{request.AdminEmail} adresi zaten kullanılıyor lütfen farklı bir adres giriniz !");
                }
            }
            catch (Exception ex)
            {

                await _mediator.Send(Factory<LoggerAddComman>.Init().Get()
                    .setLoggerTitle("Admin Kayıt")
                    .setLoggerDescription("Admin kayıt olma ve kullancı gmail kontrol işlemleri")
                    .setErrorLocation("AdminRegisterHandler | " + typeof(AdminRegisterHandler).Assembly.Location)
                    .setExceptionType(ex.GetType().ToString())
                    .setErrorMessage(ex.Message));
                    
                result.SetErrorMessage(GlobalMessage.globalError);
            }
            

            return result;
        }
    }
}
