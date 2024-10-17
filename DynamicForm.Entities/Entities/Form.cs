using DynamicForm.Entities.Common;
using DynamicForm.Entities.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Entities.Entities
{
	[EntityTypeConfiguration(typeof(FormConfiguration))]
	public class Form:BaseEntity
	{

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }

		public int CreatedBy { get; set; }

        public string Fields { get; set; }

        public AppUser AppUser { get; set; }

    }
}
