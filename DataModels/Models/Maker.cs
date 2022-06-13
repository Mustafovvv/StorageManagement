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
        [Required(ErrorMessage = "Името е задължително")]
        [StringLength(30, ErrorMessage = "{0} Дължината на името трябва да бъде между {2} and {1}.", MinimumLength = 1)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Произхода е задължителен")]
        [StringLength(10, ErrorMessage = "{0} Дължината на името трябва да бъде между {2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[а-я А-Я a-z A-Z]*$", ErrorMessage = "Не може да се въвеждат цифри!")]
        public string Country { get; set; }
        public string Experience { get; set; }

    }
}
