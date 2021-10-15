using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Todo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required Task Description!")]
        public string Desc { get; set; }
    }
}
