using AutoMapper;

namespace FurryPal.Web.AutoMapper
{
    using FurryPal.Models;
    using ViewModels.Categories;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Category, AllCategoriesViewModel>()
                .ForMember(c => c.Name, cvm => cvm.MapFrom(m => m.Name))
                .ForMember(c => c.Description, cvm => cvm.MapFrom(m => m.Description));
        }
    }
}