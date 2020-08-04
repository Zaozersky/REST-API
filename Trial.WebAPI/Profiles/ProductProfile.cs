using AutoMapper;
using Trial.WebAPI.Data.Models;
using Trial.WebAPI.ViewModels;

namespace Trial.WebAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
