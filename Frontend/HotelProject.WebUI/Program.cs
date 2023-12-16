using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddTransient<IValidator<CreateGuestDto>, CreatGuestValidator>();//guestvalidatorunu burada createuest için  aktif ediyorm.
builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();//guestvalidatorunu burada updateguest için  aktif ediyorm.
builder.Services.AddControllersWithViews().AddFluentValidation();//controlun viewsleri validator kontrolu yapdýn
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddMvc(config =>//sistem Authorize iþlemi
    {
        var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);//ne kadar zaman sonra giriþ yapmak gereksin
    options.LoginPath = "/Login/Index/";//giriþ sayfasý path veriyor
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/","?code={0}");//olmayan sayfa ve hata sayfsý için 
app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
