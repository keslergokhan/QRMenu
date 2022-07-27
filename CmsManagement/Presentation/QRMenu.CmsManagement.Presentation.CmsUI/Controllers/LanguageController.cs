using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRMenu.CmsManagement.Presentation.CmsUI.Common;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class LanguageController : BaseController
    {
        
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
        public async Task<JsonResult> Add(string deneme="")
        {
            Core.Application.Interfaces.Model.IResult result = new Core.Application.Concrete.Model.Result();

            return Json(result);
        }
    }
}
