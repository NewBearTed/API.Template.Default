using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Template.Default.Business.Model
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
