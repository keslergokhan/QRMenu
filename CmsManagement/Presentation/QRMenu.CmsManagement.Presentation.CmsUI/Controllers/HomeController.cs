using MediatR;
using Microsoft.AspNetCore.Mvc;
using QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri;
using QRMenu.CmsManagement.Infrastructure.Persistence.Configuration;
using QRMenu.CmsManagement.Presentation.CmsUI.Common;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;

        }

        public async Task<IActionResult> Index()
        {
            //var result = await _mediator.Send(new AdminGetQuery { Id = Guid.Parse("A0BAC93F-9233-4B00-A17D-C97531B3089B") });
            return View("HomeIndex");
        }
    }
}
