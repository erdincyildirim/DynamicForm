using DynamicForm.Business.Abstract;
using DynamicForm.Business.Concrete;
using DynamicForm.Business.Validators;
using DynamicForm.DataTransfer.DTOs;
using DynamicForm.Entities.Entities;
using DynamicForms.DataAccess.Abstract;
using DynamicForms.DataAccess.Concrete;
using DynamicForms.DataAccess.Contexts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Business.Extensions
{
	public static class ServiceRegistration
	{

		public static void AddRegistrationServices(this IServiceCollection services)
		{

			services.AddDbContext<DynamicContext>();

			services.AddIdentity<AppUser, AppRole>(options =>
			{

				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 5;
				options.Password.RequiredUniqueChars = 0;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.SignIn.RequireConfirmedEmail = false;


			}).AddEntityFrameworkStores<DynamicContext>();

			services.AddScoped<IFormService, FormManager>();
			services.AddScoped<IFormRepository, FormRepository>();

		}

		public static void AddValidationServices(this IServiceCollection services)
		{

			services.AddTransient<IValidator<UserLoginDto>, UserLoginValidator>();
			services.AddTransient<IValidator<CreateFormDto>, FormValidator>();

		}

		public static void AddMapperServices(this IServiceCollection services)
		{

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

		}

	}
}
