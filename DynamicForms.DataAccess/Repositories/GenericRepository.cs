using DynamicForms.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.DataAccess.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{

		private readonly DynamicContext _context;
		private readonly DbSet<T> _dbset;

		public GenericRepository(DynamicContext context)
		{
			_context = context;
			_dbset = context.Set<T>();
		}

		public async Task<bool> AddAsync(T model)
		{

			EntityEntry entityEntry = await _dbset.AddAsync(model);
			return entityEntry.State == EntityState.Added;

		}

		public IQueryable<T> GetAll(bool tracking = true)
		{
			var query = _dbset.AsQueryable();
			if (!tracking)
				query = query.AsNoTracking();
			return query;
		}

		public async Task ExecuteUpdateAsync(Expression<Func<T, bool>> condition, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> expression)
		{
			await _dbset.Where(condition).ExecuteUpdateAsync(expression);
		}

		public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> condition, bool tracking = true)
		{

			var query = _dbset.Where(condition);
			if (!tracking)
				query = query.AsNoTracking();
			return query;

		}
	}
}
