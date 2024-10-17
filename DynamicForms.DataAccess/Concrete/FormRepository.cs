using DynamicForm.Entities.Entities;
using DynamicForms.DataAccess.Abstract;
using DynamicForms.DataAccess.Contexts;
using DynamicForms.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.DataAccess.Concrete
{
	public class FormRepository : GenericRepository<Form>, IFormRepository
	{
		public FormRepository(DynamicContext context) : base(context)
		{

		}
	}
}
