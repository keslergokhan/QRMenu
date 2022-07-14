using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace QRMenu.CmsManagement.Presentation.CmsUI.Helpers
{
	public static class Helpers
	{
		/// <summary>
		///		Giriş yapmış olan kullanıcının(admin) Adı değerini verir
		/// </summary>
		/// <returns>string</returns>
		public static string getUserName()
		{
			return ClaimsPrincipal.Current?.FindFirstValue(ClaimTypes.Name) ?? "null";
		}

		/// <summary>
		///		Giriş yapmış olan kullanıcının(admin) Adı ve Soyadını değerini verir
		/// </summary>
		/// <returns>string</returns>
		public static string getUserNameAndSurname()
		{
			return (
				(ClaimsPrincipal.Current?.FindFirstValue(ClaimTypes.Name) ?? "null") + 
				(ClaimsPrincipal.Current?.FindFirstValue(ClaimTypes.Surname) ?? "null")
				);
		}



		/// <summary>
		///		Giriş yapmış olan kullanıcının(admin) email değerini verir
		/// </summary>
		/// <returns>string</returns>
		public static string getUserEmail()
		{
			return ClaimsPrincipal.Current?.FindFirstValue(ClaimTypes.Email) ?? "null";
		}

		/// <summary>
		///		Giriş yapmış olan kullanıcının(admin) soyadı değerini verir
		/// </summary>
		/// <returns>string</returns>
		public static string getUserSurname()
		{
			return ClaimsPrincipal.Current?.FindFirstValue(ClaimTypes.Surname) ?? "null";
		}

		/// <summary>
		///		Giriş yapmış olan kullanıcının(admin) Guid değerini verir
		/// </summary>
		/// <returns>string</returns>
		public static string getUserId()
		{
			return ClaimsPrincipal.Current?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "null";
		}
	}
}
