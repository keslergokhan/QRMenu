using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRMenu.CmsManagement.Presentation.CmsUI.Common;
using QRMenu.CmsManagement.Presentation.CmsUI.Extensions;
using QRMenu.CmsManagement.Presentation.CmsUI.Helpers;

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

        public async Task<IActionResult> AdminProfile()
        {
            ViewBag.Title = "Admin Profil Yönetimi";

            return View("CmsAdminProfile");
        }
    }
}
