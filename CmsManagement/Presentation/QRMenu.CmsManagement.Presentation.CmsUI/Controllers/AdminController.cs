using Microsoft.AspNetCore.Mvc;
using QRMenu.CmsManagement.Presentation.CmsUI.Common;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command;
using QRMenu.CmsManagement.Core.Application.Exceptions;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using AutoMapper;
using QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries;
using QRMenu.CmsManagement.Core.Application.Concrete.Factories;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Controllers
{
    public class AdminController : BaseController
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public AdminController(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        /// <summary>
        ///     Admin kayıt
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Register()
        {
            return View();
        }

        /// <summary>
        ///     Admin kayıt post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> RegisterPost(AdminRegisterComman comman)
        {
            var result = new ResultData<AdminReadDto>();

            try
            {
                var sendResult = await _mediator.Send(comman);
                result.Data = _mapper.Map<AdminReadDto>(comman);

                if (sendResult.Status == Core.Application.Enums.ResultStatusEnum.Success)
                {
                    result.Data.Id = sendResult.Data;
                    result.SetSuccessMessage($"Aramıza hoş gelidniz, {comman.AdminName} {comman.AdminSurName}");
                }
                else
                {
                    result.SetWarningMessage(sendResult.Message);
                }

            }
            catch (FluentValidationException ex)
            {
                result.SetErrorMessage(ex.Message).SetException(ex);
            }
            catch (Exception ex)
            {
                await _mediator.Send(Factory<LoggerAddComman>.Init()
                    .SetVale(x => x.LoggerTitle, "Admin Kayıt")
                    .SetVale(x => x.LoggerDescription, "Admin kayıt olma ve kullancı gmail kontrol işlemleri")
                    .SetVale(x => x.ErrorLocation, "AdminController,RegisterPost | " + typeof(AdminController).Assembly.Location)
                    .SetVale(x => x.ExceptionType, ex.GetType().ToString())
                    .SetVale(x => x.ErrorMessage, ex.Message)
                    .Get()
                );
                result.SetErrorMessage(ex.Message).SetException(ex);
            }

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> LoginPost(AdminLoginQuery adminLoginQuery)
        {
            IResultData<AdminReadDto> result = new ResultData<AdminReadDto>();
            try
            {
                result = await _mediator.Send(adminLoginQuery);
            }
            catch (FluentValidationException ex)
            {
                result.SetErrorMessage(ex.Message);
            }
            catch (Exception ex)
            {

                await _mediator.Send(Factory<LoggerAddComman>.Init()
                    .SetVale(x => x.LoggerTitle, "Admin Giris")
                    .SetVale(x => x.LoggerDescription, "Admin giris, admin kimlik bilgilerinin kontrolu")
                    .SetVale(x => x.ErrorLocation, "AdminController,LoginPost | " + typeof(AdminController).Assembly.Location)
                    .SetVale(x => x.ExceptionType, ex.GetType().ToString())
                    .SetVale(x => x.ErrorMessage, ex.Message)
                    .Get()
                );
                result.SetErrorMessage(ex.Message);
            }

            return Json(result.ClearException());
        }
    }
}
