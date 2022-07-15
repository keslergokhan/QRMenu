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
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
            if (User.Identity.IsAuthenticated is false)
                return View();
            else
                return RedirectToAction("Index","Cms");
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
                await _mediator.Send(Factory<LoggerAddComman>.Init().Get()
                    .setLoggerTitle("Admin Kayıt")
                    .setLoggerDescription("Admin kayıt olma ve kullancı gmail kontrol işlemleri")
                    .setErrorLocation("AdminController,RegisterPost | " + typeof(AdminController).Assembly.Location)
                    .setExceptionType(ex.GetType().ToString())
                    .setErrorMessage(ex.Message));

                result.SetErrorMessage(ex.Message).SetException(ex);
            }

            return Json(result);
        }

        
        /// <summary>
        ///     Admin giriş işlemleri / form post
        /// </summary>
        /// <param name="adminLoginQuery"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> LoginPost(AdminLoginQuery adminLoginQuery)
        {
            IResultData<AdminReadDto> result = new ResultData<AdminReadDto>();
            try
            {
                result = await _mediator.Send(adminLoginQuery);
                
                //Giriş başarılı ise
                if (result.Status == Core.Application.Enums.ResultStatusEnum.Success)
                {
                    List<Claim> adminClai = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,result.Data.Id.ToString()),
                        new Claim(ClaimTypes.Name,result.Data.AdminName),
                        new Claim(ClaimTypes.Surname,result.Data.AdminSurName),
                        new Claim(ClaimTypes.Email,result.Data.AdminEmail),
                        new Claim(ClaimTypes.Role,"admin"),
                        new Claim("deneme","gokhanbaba"),
                    };

                    //Beni hatırla
                    AuthenticationProperties autPersistent = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };

                    var adminIdentity = new ClaimsIdentity(adminClai, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(adminIdentity), autPersistent);
                }

                

            }
            catch (FluentValidationException ex)
            {
                result.SetErrorMessage(ex.Message);
            }
            catch (Exception ex)
            {
                await _mediator.Send(Factory<LoggerAddComman>.Init().Get()
                    .setLoggerTitle("Admin Giris")
                    .setLoggerDescription("Admin giris, admin kimlik bilgilerinin kontrolu")
                    .setErrorLocation("AdminController,LoginPost | " + typeof(AdminController).Assembly.Location)
                    .setExceptionType(ex.GetType().ToString())
                    .setErrorMessage(ex.Message));

                result.SetErrorMessage(ex.Message);
            }

            return Json(result.ClearException());
        }


        /// <summary>
        ///     Güvenli çıkış
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
