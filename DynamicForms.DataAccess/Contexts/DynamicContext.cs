using DynamicForm.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.DataAccess.Contexts
{
	public class DynamicContext:IdentityDbContext<AppUser,AppRole,int>
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			optionsBuilder.UseSqlServer("Server=.; Database=DynamicForm; Integrated Security=True; TrustServerCertificate=True");

		}

        public DbSet<Form> Forms { get; set; }

    }
}
