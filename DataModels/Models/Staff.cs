using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Staff:BaseModel
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
    }
}
