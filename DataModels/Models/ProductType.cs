using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
   public class ProductType:BaseModel
    {
        [Required(ErrorMessage = "Името е задължително")]
        [StringLength(30, ErrorMessage = "{0} Дължината на името трябва да бъде между {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
