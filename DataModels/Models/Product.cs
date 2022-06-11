using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
   public class Product:BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Standart { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int MakerId { get; set; }
        public Maker Maker { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

    }
}
