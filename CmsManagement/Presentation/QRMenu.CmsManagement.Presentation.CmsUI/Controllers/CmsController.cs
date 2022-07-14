using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRMenu.CmsManagement.Presentation.CmsUI.Common;
using QRMenu.CmsManagement.Presentation.CmsUI.Extensions;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Controllers
{
    public class CmsController : BaseController
    {
        private readonly IMediator _mediator;

        public CmsController(IMediator mediator)
        {

        }


        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {


            //var result = await _mediator.Send(new AdminGetQuery { Id = Guid.Parse("A0BAC93F-9233-4B00-A17D-C97531B3089B") });
            return View("CmsIndex");
        }
    }
}
