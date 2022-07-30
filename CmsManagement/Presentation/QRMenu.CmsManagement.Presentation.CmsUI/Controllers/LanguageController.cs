using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LanguageCommand.Command;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Presentation.CmsUI.Common;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class LanguageController : BaseController
    {
        private readonly IMediator _mediator;
        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.Title = "Aktif Diller";
            return View("LanguagesList");
        }

        [HttpGet]

        public async Task<IActionResult> Add()
        {
            ViewBag.Title = "Yeni Dil Ekle";
            return View("LanguageAdd");
        }

        [HttpPost]
        public async Task<JsonResult> Add(LanguageAddCommand languageAddCommand)
        {
            IResultData<Guid> result = new ResultData<Guid>();

            try
            {
                IResultData<Guid> addResult = await _mediator.Send(languageAddCommand);
                result = addResult;

            }
            catch (Exception ex)
            {

                result.SetErrorMessage(GlobalMessage.globalError);
            }

            return Json(result);
        }
    }
}
