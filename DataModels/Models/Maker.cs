using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
   public class Maker : BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "{0} Lenght must be Between {2} and {1}.", MinimumLength = 1)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Origin is required")]
        [StringLength(10, ErrorMessage = "{0} Name lenght must be  {2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[а-я А-Я a-z A-Z]*$", ErrorMessage = "Can't write numbers!")]
        public string Country { get; set; }
        public string Experience { get; set; }

    }
}
