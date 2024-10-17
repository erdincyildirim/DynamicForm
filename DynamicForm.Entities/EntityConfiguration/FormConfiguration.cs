using DynamicForm.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Entities.EntityConfiguration
{
	public class FormConfiguration : IEntityTypeConfiguration<Form>
	{

		public void Configure(EntityTypeBuilder<Form> builder)
		{

			builder.ToTable("Forms");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnName("Name").HasColumnType("varchar");
			builder.Property(x => x.Description).IsRequired(false).HasMaxLength(250).HasColumnName("Description").HasColumnType("varchar");
			builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()").HasColumnName("CreatedAt").HasColumnType("datetime");
			builder.Property(x => x.CreatedBy).IsRequired().HasColumnName("CreatedBy").HasColumnType("int");
			builder.Property(x => x.Fields).IsRequired().HasColumnName("Fields").HasColumnType("varchar(MAX)");
			builder.Property(x => x.IsDeleted).HasDefaultValue(false).HasColumnName("IsDeleted").HasColumnType("bit");

			builder.HasOne(x => x.AppUser).WithMany(x => x.Forms).HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.NoAction);

		}

	}
}
