using API.Template.Default.Business.Model;
using API.Template.Default.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Template.Default.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
