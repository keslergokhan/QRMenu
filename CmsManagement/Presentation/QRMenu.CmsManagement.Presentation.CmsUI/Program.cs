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

    #region Login/Post & Register/Post & Logout
    app.MapControllerRoute(name: "registerPost", pattern: "kayit", defaults: new { controller = "Admin", action = "RegisterPost" });
    app.MapControllerRoute(name: "registerPost", pattern: "giris", defaults: new { controller = "Admin", action = "LoginPost" });
    

    app.MapControllerRoute(name: "login", pattern: "giris", defaults: new { controller = "Admin", action = "Login" });
    app.MapControllerRoute(name: "register", pattern: "kayit", defaults: new { controller = "Admin", action = "Register" });
    app.MapControllerRoute(name:"logout","guvenli-cikis",defaults:new {controller = "Admin",action = "Logout" });
    #endregion Login/Post & Register/Post & Logout


    #region Cms
    app.MapControllerRoute(name: "cmshome", pattern: "yonetim", defaults: new { controller = "Cms", action = "Index" });
    
    //admin profil
    app.MapControllerRoute(name: "cmsAdminProfile", pattern: "yonetici-profil/{id}", defaults: new {controller = "Cms", action = "AdminProfile" });
    app.MapControllerRoute(name: "cmsAdminProfileUpdate",pattern: "cms-yonetici-guncelle",defaults:new {controller="Cms",action="AdminProfileUpdate"});

    app.MapControllerRoute(name: "cmsLanguages", pattern: "diller",defaults: new {controller = "Language",action = "List"});
    app.MapControllerRoute(name: "cmsLanguages", pattern: "dil-ekle", defaults: new { controller = "Language", action = "Add" });


#endregion Cms End




#endregion

app.MapControllerRoute(name: "default", pattern:"{controller=Admin}/{action=login}");
app.MapDefaultControllerRoute();

app.Run();
