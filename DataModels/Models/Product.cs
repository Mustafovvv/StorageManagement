using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataModels
{
   public class Product:BaseModel
    {
        [Required (ErrorMessage = "Името е задължително")] 
        [StringLength(30, ErrorMessage = "{0} Дължината на името трябва да бъде между {2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[а-я А-Я a-z A-Z]*$", ErrorMessage = "Не може да се въвеждат цифри!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Количеството е задължително")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Стандарта е задължителен")]
        public string Standart { get; set; }
        [Required(ErrorMessage = "Срока на годност е задължително")]
        public DateTime ExpiryDate { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int MakerId { get; set; }
        public Maker Maker { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

    }
}
