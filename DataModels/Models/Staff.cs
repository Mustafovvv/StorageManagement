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
        [Required(ErrorMessage = "Името е задължително")]
        [StringLength(30, ErrorMessage = "{0} Дължината на името трябва да бъде между {2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[а-я А-Я a-z A-Z]*$", ErrorMessage = "Не може да се въвеждат цифри!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Датата на раждане е задължително")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Денят на назначение е задължително")]
        public DateTime AppointedDay { get; set; }
        [Required(ErrorMessage = "Длъжността е задължителна")]
        public string Position { get; set; } 
        
        public DateTime? FiredDay  { get; set; }
    }
}
