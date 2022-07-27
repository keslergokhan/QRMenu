using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRMenu.CmsManagement.Presentation.CmsUI.Common;
using QRMenu.CmsManagement.Presentation.CmsUI.Extensions;
using QRMenu.CmsManagement.Presentation.CmsUI.Helpers;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Concrete.Factories;
using QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries;
using QRMenu.CmsManagement.Presentation.CmsUI.Models.Admins;
using QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CmsController : BaseController
    {
        private readonly IMediator _mediator;

        public CmsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        public async Task<IActionResult> Index()
        {
            return View("CmsIndex");
        }

        public async Task<IActionResult> AdminProfile(Guid id)
        {
            AdminProfileOutViewModel model = new AdminProfileOutViewModel();
            
            AdminGetQuery query = Factory<AdminGetQuery>.Init().Get();
            query.Id = id;

            ViewBag.Title = "Admin Profil Yönetimi";
            IResultData<AdminReadDto> result = await _mediator.Send(query);

            if (result.Status == Core.Application.Enums.ResultStatusEnum.Success)
            {
                model.AdminReadDto = result.Data;
                ViewBag.Title = $"Admin {result.Data.AdminName} {result.Data.AdminSurName} profil";
            }
            else
            {
                return RedirectToAction("Index");
            }
                
            return View("CmsAdminProfile", model);
        }

        [HttpPost]
        public async Task<JsonResult> AdminProfileUpdate(AdminProfileUpdateComman query)
        {
            Core.Application.Interfaces.Model.IResult result = new Result();

            try
            {
                result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                await _mediator.Send(Factory<LoggerAddComman>.Init().Get()
                    .setLoggerTitle("Admin Güncelleme")
                    .setLoggerDescription("Admin profil güncelleme işlemleri")
                    .setErrorLocation("CmsController => AdminProfileUpdate() | " + typeof(CmsController).Assembly.Location)
                    .setExceptionType(ex.GetType().ToString())
                    .setErrorMessage(ex.Message));

                result.SetErrorMessage(ex.Message);
            }

            return Json(result);
        }

        
    }
}
