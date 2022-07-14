using Microsoft.AspNetCore.Authentication.Cookies;
using QRMenu.CmsManagement.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistenceService();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt=> {
    opt.Cookie.Name = "app_qmenu_cms_cookie";
    opt.LoginPath = new PathString("/giris");
    opt.AccessDeniedPath = new PathString("/giris");
});



// Add services to the container.
var razorPage = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    razorPage.AddRazorRuntimeCompilation();
}

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

#region Admin

    #region AjaxPost\Get
    app.MapControllerRoute(name: "registerPost", pattern: "kayit", defaults: new { controller = "admin", action = "RegisterPost" });
    app.MapControllerRoute(name: "registerPost", pattern: "giris", defaults: new { controller = "admin", action = "LoginPost" });
    #endregion Post\GetEnd

    app.MapControllerRoute(name: "login", pattern: "giris", defaults: new { controller = "admin", action = "Login" });
    app.MapControllerRoute(name: "register", pattern: "kayit", defaults: new { controller = "admin", action = "Register" });


    app.MapControllerRoute(name: "cmshome", pattern: "yonetim", defaults: new { controller = "Cms", action = "Index" });

#endregion

app.MapControllerRoute(name: "default", pattern:"{controller=Admin}/{action=login}");
app.MapDefaultControllerRoute();

app.Run();
