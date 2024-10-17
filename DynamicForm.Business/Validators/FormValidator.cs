using DynamicForm.DataTransfer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Business.Validators
{
    public class FormValidator:AbstractValidator<CreateFormDto>
    {

        public FormValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(" * Form adı giriniz !").MaximumLength(50).WithMessage(" * Max. 50 karakter girilebilir !");
        }

    }
}
