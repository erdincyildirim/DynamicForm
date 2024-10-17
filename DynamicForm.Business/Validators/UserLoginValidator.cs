using DynamicForm.DataTransfer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Business.Validators
{
	public class UserLoginValidator:AbstractValidator<UserLoginDto>
	{

        public UserLoginValidator()
        {

			RuleFor(x => x.Username).NotEmpty().WithMessage("* Kullanıcı adı giriniz !").MaximumLength(50).WithMessage("* Max. 50 karakter girilebilir !");
			RuleFor(x => x.Password).NotEmpty().WithMessage("* Parola giriniz !").MaximumLength(50).WithMessage("* Max. 50 karakter girilebilir !");

		}

    }
}
