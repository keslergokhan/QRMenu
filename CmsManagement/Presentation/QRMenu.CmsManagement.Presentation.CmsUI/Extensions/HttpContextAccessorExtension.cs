using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Extensions
{
	public static class HttpContextAccessorExtension
	{
		/// <summary>
		///		Kullanıcı(admin) Ad bilgisini döndürür
		/// </summary>
		/// <param name="httpContextAccessor"></param>
		/// <returns>string</returns>
		public static string GetUserName(this IHttpContextAccessor httpContextAccessor)
		{
			return httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "null";
		}

		/// <summary>
		///		Kullanıcı(admin) ad ve soyad bilgisini döndürür
		/// </summary>
		/// <param name="httpContextAccessor"></param>
		/// <returns>string</returns>
		public static string GetUserNameAndSurname(this IHttpContextAccessor httpContextAccessor)
		{
			return (httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "null") + " " + (httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Surname) ?? "null");
		}

		/// <summary>
		///		Kullanıcı email bilgisni döndürür
		/// </summary>
		/// <param name="httpContextAccessor"></param>
		/// <returns>string</returns>
		public static string GetUserEmail(this IHttpContextAccessor httpContextAccessor)
		{
			return httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email) ?? "null";
		}


		/// <summary>
		///		Kullanıcı(admin) Id bilgisini döndürür
		/// </summary>
		/// <param name="httpContextAccessor"></param>
		/// <returns></returns>
		public static string GetUserId(this IHttpContextAccessor httpContextAccessor)
		{
			return httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "null";
		}
	}
}
