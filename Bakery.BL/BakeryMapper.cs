using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bakery.DAL.Models;
using Bakery.ViewModel;

namespace Bakery.BL
{
    public class BakeryMapper : IBakeryMapper
    {
        public IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                 .ForMember(dst => dst.Image, opt => opt.MapFrom(src => src.Url));
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<ProductViewModel, Product>()
                    .ForMember(dst => dst.Url, opt => opt.MapFrom(src => src.Image));
                cfg.CreateMap<LoginViewModel, User>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Role, RoleViewModel>();
                cfg.CreateMap<RegisterViewModel, User>();
            }).CreateMapper();
        }
    }
}
