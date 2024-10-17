using AutoMapper;
using DynamicForm.DataTransfer.DTOs;
using DynamicForm.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Business.Mappers
{
	public class FormProfile:Profile
	{

        public FormProfile()
        {
            CreateMap<CreateFormDto, Form>();
        }

    }
}
