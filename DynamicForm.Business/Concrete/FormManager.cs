using AutoMapper;
using DynamicForm.Business.Abstract;
using DynamicForm.DataTransfer.DTOs;
using DynamicForm.Entities.Entities;
using DynamicForms.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Business.Concrete
{
	public class FormManager : IFormService
	{

		private readonly IFormRepository _formRepository;
		private readonly IMapper _mapper;

		public FormManager(IFormRepository formRepository, IMapper mapper)
		{
			_formRepository = formRepository;
			_mapper = mapper;
		}

		public async Task AddAsync(CreateFormDto createFormDto)
		{

			Form form = _mapper.Map<Form>(createFormDto);

			await _formRepository.AddAsync(form);
			await _formRepository.SaveAsync();
		}

		public async Task<List<FormListDto>> GetAllAsync()
		{

			return await _formRepository.GetAll().Include(x => x.AppUser).Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id).Select(x => new FormListDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description == null ? "-" : x.Description,
				CreatedAt = x.CreatedAt.ToString("dd.MM.yyyy HH:mm:ss"),
				CreatedBy = x.AppUser.UserName
			}).ToListAsync();

		}

		public async Task<FormFieldsDto> GetByIdAsync(int id)
		{
			return await _formRepository.GetWhere(x => x.Id == id).Select(x => new FormFieldsDto
			{
				Id = x.Id,
				Fields = x.Fields
			}).FirstOrDefaultAsync();
		}

		public async Task SoftDeleteAsync(int id)
		{

			await _formRepository.ExecuteUpdateAsync(x => x.Id == id, x => x.SetProperty(x => x.IsDeleted, true));

		}
	}
}
