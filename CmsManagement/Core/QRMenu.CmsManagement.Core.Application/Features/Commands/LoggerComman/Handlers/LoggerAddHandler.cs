using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using QRMenu.CmsManagement.Core.Application.Concrete.Factories;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Core.Domain.Entities;

namespace QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Handlers
{
    /// <summary>
    ///     Yeni bir logger verisi ekler
    /// </summary>
    public class LoggerAddHandler : IRequestHandler<LoggerAddComman, IResult>
    {
        private readonly IWriteRepository<Logger> _loggerRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public LoggerAddHandler(IWriteRepository<Logger> loggerRepository, IMapper mapper, IMediator mediator)
        {
            _loggerRepository = loggerRepository;
            _mapper = mapper;
            _mediator = _mediator;
        }

        public async Task<IResult> Handle(LoggerAddComman request, CancellationToken cancellationToken)
        {
            IResult result = new Result();
            try
            {
                IResultData<Guid> loggerAdd = await _loggerRepository.AddAsync(_mapper.Map<Logger>(request));
                if (loggerAdd.Status == Enums.ResultStatusEnum.Success)
                    return result.SetSuccessMessage(GlobalMessage.globalSuccess);
                else
                    return result.SetWarningMessage(loggerAdd.Message);
                
            }
            catch (Exception ex)
            {
                await _mediator.Send(Factory<LoggerAddComman>.Init().Get()
                    .setLoggerTitle("Admin Kayıt")
                    .setLoggerDescription("Admin kayıt olma ve kullancı gmail kontrol işlemleri")
                    .setErrorLocation("AdminRegisterHandler | " + typeof(LoggerAddHandler).Assembly.Location)
                    .setExceptionType(ex.GetType().ToString())
                    .setErrorMessage(ex.Message));

                return result.SetErrorMessage(ex.Message).SetException(ex);
            }
        }
    }
}
