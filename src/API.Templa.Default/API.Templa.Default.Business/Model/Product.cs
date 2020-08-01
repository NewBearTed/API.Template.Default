using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Templa.Default.Business.Model
{
    public class Product : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
