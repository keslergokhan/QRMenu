using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Extensions
{
	public static class HttpContextAccessorExtension
	{
		public static string UserGetName(this IHttpContextAccessor httpContextAccessor)
		{
			return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
		}
	}
}
