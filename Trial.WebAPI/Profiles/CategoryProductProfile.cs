using AutoMapper;
using Trial.WebAPI.Data.Models;
using Trial.WebAPI.ViewModels;

namespace Trial.WebAPI.Profiles
{
    public class CategoryProductProfile : Profile
    {
        public CategoryProductProfile()
        {
            CreateMap<CategoryProduct, CategoryProductViewModel>();
            CreateMap<CategoryProductViewModel, CategoryProduct>();
        }
    }
}
