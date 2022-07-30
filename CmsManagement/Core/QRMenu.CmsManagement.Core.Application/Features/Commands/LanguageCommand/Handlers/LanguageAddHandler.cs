using AutoMapper;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Concrete.Factories;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LanguageCommand.Command;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.LanguageCommand.Handlers
{
    /// <summary>
    ///     Yeni bir dil ekleme işlemi
    /// </summary>
    public class LanguageAddHandler : IRequestHandler<LanguageAddCommand, IResultData<Guid>>
    {
        private readonly IMediator _mediator;
        private readonly IWriteRepository<Language> _languageRepostiry;
        private readonly IMapper _mapper;

        public LanguageAddHandler(IWriteRepository<Language> languageRepostiry, IMapper mapper = null, IMediator mediator = null)
        {
            _languageRepostiry = languageRepostiry;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IResultData<Guid>> Handle(LanguageAddCommand request, CancellationToken cancellationToken)
        {
            IResultData<Guid> result = new ResultData<Guid>();

            try
            {
                result = await _languageRepostiry.AddAsync(_mapper.Map<Language>(request));
                if (result.Status == Enums.ResultStatusEnum.Error)
                    throw new Exception(result.ErrorMessage);
                _languageRepostiry.Dispose();

            }
            catch (Exception ex)
            {
                await _mediator.Send(Factory<LoggerAddComman>.Init().Get()
                    .setLoggerTitle("Dil ekleme işlemi")
                    .setLoggerDescription("Yeni aktif bir dil ekleme işlemi")
                    .setErrorLocation("LanguageAddHandler | " + typeof(LanguageAddHandler).Assembly.Location)
                    .setExceptionType(ex.GetType().ToString())
                    .setErrorMessage(ex.Message));

                result.SetErrorMessage(GlobalMessage.globalError);
            }
            return result;
        }
    }
}
