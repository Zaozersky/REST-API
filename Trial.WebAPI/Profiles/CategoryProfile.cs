using AutoMapper;
using Trial.WebAPI.Data.Models;
using Trial.WebAPI.ViewModels;

namespace Trial.WebAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
        }
    }
}
