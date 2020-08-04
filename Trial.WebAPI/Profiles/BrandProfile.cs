using AutoMapper;
using Trial.WebAPI.Data.Models;
using Trial.WebAPI.ViewModels;

namespace Trial.WebAPI.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();
        }
    }
}
