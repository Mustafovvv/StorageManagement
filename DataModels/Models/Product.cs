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
        [Required (ErrorMessage = "Name is required")] 
        [StringLength(30, ErrorMessage = "{0} lenght must be between{2} and {1}.", MinimumLength = 3)]
        [RegularExpression("^[а-я А-Я a-z A-Z]*$", ErrorMessage = "Can't write numbers!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Standart is required")]
        public string Standart { get; set; }
        [Required(ErrorMessage = "Expiry day is required")]
        public DateTime ExpiryDate { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int MakerId { get; set; }
        public Maker Maker { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

    }
}
