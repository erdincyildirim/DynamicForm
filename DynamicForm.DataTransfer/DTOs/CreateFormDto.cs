using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.DataTransfer.DTOs
{
    public class CreateFormDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Fields { get; set; }

        public string CreatedBy { get; set; }

    }
}
