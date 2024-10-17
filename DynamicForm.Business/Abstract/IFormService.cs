using DynamicForm.DataTransfer.DTOs;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Business.Abstract
{
	public interface IFormService
	{

		public Task AddAsync(CreateFormDto createFormDto);

		public Task<List<FormListDto>> GetAllAsync();

		public Task<FormFieldsDto> GetByIdAsync(int id);

		public Task SoftDeleteAsync(int id);

	}
}
