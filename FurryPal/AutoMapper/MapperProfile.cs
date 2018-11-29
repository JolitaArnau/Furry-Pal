using AutoMapper;
using FurryPal.Web.Areas.Admin.ViewModels.Categories;
using FurryPal.Web.Areas.Admin.ViewModels.Manufacturers;

namespace FurryPal.Web.AutoMapper
{
    using FurryPal.Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Category, AllCategoriesViewModel>()
                .ForMember(c => c.Name, cvm => cvm.MapFrom(m => m.Name))
                .ForMember(c => c.Description, cvm => cvm.MapFrom(m => m.Description))
                .ForMember(c => c.Id, cvm => cvm.MapFrom(m => m.Id));

            this.CreateMap<Category, EditDeleteCategoryViewModel>()
                .ForMember(c => c.Name, cvm => cvm.MapFrom(m => m.Name))
                .ForMember(c => c.Description, cvm => cvm.MapFrom(m => m.Description))
                .ForMember(c => c.Id, cvm => cvm.MapFrom(m => m.Id));

            this.CreateMap<Manufacturer, AllManufacturersViewModel>()
                .ForMember(c => c.Name, cvm => cvm.MapFrom(m => m.Name))
                .ForMember(c => c.Email, cvm => cvm.MapFrom(m => m.Email))
                .ForMember(c => c.PhoneNumber, cvm => cvm.MapFrom(m => m.PhoneNumber));

            this.CreateMap<Manufacturer, EditDeleteManufacturerViewModel>()
                .ForMember(c => c.Id, cvm => cvm.MapFrom(m => m.Id))
                .ForMember(c => c.Name, cvm => cvm.MapFrom(m => m.Name))
                .ForMember(c => c.Email, cvm => cvm.MapFrom(m => m.Email))
                .ForMember(c => c.PhoneNumber, cvm => cvm.MapFrom(m => m.PhoneNumber));
        }
    }
}