using AutoMapper;
using Core.Entities;

namespace WebApi.DTOs
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.CategoryName, c => c.MapFrom(cn => cn.Category.Name))
                .ForMember(p => p.TraderMarkName, t => t.MapFrom(cn => cn.TraderMark.Name));
        }
    }
}
