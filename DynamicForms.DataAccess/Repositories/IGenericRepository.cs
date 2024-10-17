using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.DataAccess.Repositories
{
	public interface IGenericRepository<T> where T:class
	{

		Task<bool> AddAsync(T model);

		IQueryable<T> GetAll(bool tracking = true);

		Task ExecuteUpdateAsync(Expression<Func<T, bool>> condition, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> expression);

		IQueryable<T> GetWhere(Expression<Func<T, bool>> condition, bool tracking = true);

		Task<int> SaveAsync();

	}
}
