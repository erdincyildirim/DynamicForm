using DynamicForm.Business.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidationServices();

builder.Services.AddMapperServices();

builder.Services.AddRegistrationServices();

builder.Services.AddControllersWithViews().AddFluentValidation().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNamingPolicy = null;
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddControllers(config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = new PathString("/Login/Index");
	options.LogoutPath = new PathString("/Login/Logout");
	options.SlidingExpiration = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(name: "Default", pattern: "{Controller=Login}/{Action=Index}/{id?}");

app.Run();
