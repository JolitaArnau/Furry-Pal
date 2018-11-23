using AutoMapper;
using FurryPal.Web.ViewModels.Manufacturers;

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
            
            this.CreateMap<Manufacturer, AllManufacturersViewModel>()
                .ForMember(c => c.Name, cvm => cvm.MapFrom(m => m.Name))
                .ForMember(c => c.Email, cvm => cvm.MapFrom(m => m.Email))
                .ForMember(c => c.PhoneNumber, cvm => cvm.MapFrom(m => m.PhoneNumber));
        }
    }
}