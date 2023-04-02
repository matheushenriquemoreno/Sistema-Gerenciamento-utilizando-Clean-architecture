using System.Buffers;
using CleanArchMVC.Domain.Account;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.IOC;
using CleanArchMVC.WebUI.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Login/Login");
builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Login/Login");


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


using var servicoEcope = app.Services.CreateScope();
var servico = servicoEcope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();

servico.SeedRoles();
servico.SeedUsers();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}");

app.Run();
