using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
   public class Maker : BaseModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Experience { get; set; }

    }
}
