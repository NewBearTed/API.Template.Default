using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Template.Default.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
