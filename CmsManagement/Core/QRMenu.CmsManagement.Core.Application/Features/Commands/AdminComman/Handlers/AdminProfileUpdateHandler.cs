using AutoMapper;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Concrete.Factories;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Handlers
{
    public class AdminProfileUpdateHandler : IRequestHandler<AdminProfileUpdateComman, IResult>
    {
        private readonly IMediator _mediator;
        private readonly IWriteRepository<Admin> _writeRepository;
        private readonly IReadRepository<Admin> _readRepository;
        private readonly IMapper _mapper;

        public AdminProfileUpdateHandler(IWriteRepository<Admin> writeRepository, IMediator mediator, IMapper mapper, IReadRepository<Admin> readRepository)
        {
            this._writeRepository = writeRepository;
            this._mediator = mediator;
            this._mapper = mapper;
            this._readRepository = readRepository;
        }


        //Cms admin profilini güncelleme
        public async Task<IResult> Handle(AdminProfileUpdateComman request, CancellationToken cancellationToken)
        {
            IResult result = new Result();

            IResultData<Admin> admin = await _readRepository.GetFindIdAsync(request.Id);
            if (admin.Status != Enums.ResultStatusEnum.Success || admin == null)
                throw new Exception("Kullanıcı bilgilerine ulaşılamadı lütfen daha sonra terkar deneyin !");

            try
            {
                #region Gmail adresini güncelleme
                //Post değeri içerisinde gönderilen gmail adresi mevcut gmail adresinden farklı ise
                if (request.AdminEmail.Equals(admin.Data.AdminEmail) == false)
                {
                    //Yeni gmail adresi sistemde kayıtlı mı kontrol et
                    IResultData<Admin> findResult = await _readRepository.Query().Where(x => x.AdminEmail == request.AdminEmail).FirstOrDefaultAsync();
                    if (findResult.Status == Enums.ResultStatusEnum.Success && findResult.Data != null)
                    {
                        result.SetWarningMessage($"{request.AdminEmail} adresi zaten mevcut lütfen farklı bir adres deneyiniz !");
                        return result;
                    }
                }
                #endregion

                #region Şifre güncelleme
                //Kullanıcı şifresini güncellemek istediği taktirde şifre kontrolu yapıldı
                if (string.IsNullOrEmpty(request.AdminPassword) != true)
                {
                    if (request.AdminPassword.Equals(admin.Data.AdminPassword) == false)
                    {
                        result.SetWarningMessage("Şifrenizi güncellemek için mevcut şifreinizi doğru girmeniz gerekli !");
                        return result;
                    }
                    else
                    {
                        request.AdminPassword = request.AdminPasswordNew;
                    }
                }
                else
                {
                    request.AdminPassword = admin.Data?.AdminPassword;
                }
                #endregion

                result = await this._writeRepository.UpdateAsync(this._mapper.Map<Admin>(request));
                
            }
            catch (Exception ex)
            {
                await _mediator.Send(Factory<LoggerAddComman>.Init().Get()
                    .setLoggerTitle("Admin Güncelleme")
                    .setLoggerDescription("Admin profil güncelleme işlemleri")
                    .setErrorLocation("AdminProfileUpdateHandler | " + typeof(AdminProfileUpdateHandler).Assembly.Location)
                    .setExceptionType(ex.GetType().ToString())
                    .setErrorMessage(ex.Message));
                    
                result.SetErrorMessage(GlobalMessage.globalError);
            }

            return result;
        }
    }
}
