using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Entities.Entities
{
	public class AppUser:IdentityUser<int>
	{

        public ICollection<Form> Forms { get; set; }

    }
}
