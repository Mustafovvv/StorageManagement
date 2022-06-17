using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Staff:BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "{0}  lenght must be between {2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[а-я А-Я a-z A-Z ]*$", ErrorMessage = "Can't write numbers!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Appointed day is required")]
        public DateTime AppointedDay { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; } 
        
        public DateTime? FiredDay  { get; set; }
    }
}
