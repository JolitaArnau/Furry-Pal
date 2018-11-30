using AutoMapper;
namespace FurryPal.Web.AutoMapper
{
    using FurryPal.Models;
    using Areas.Admin.ViewModels.Categories;
    using Areas.Admin.ViewModels.Manufacturers;
    using Areas.Admin.ViewModels.Products;

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

            this.CreateMap<Product, AllProductsViewModel>()
                .ForMember(p => p.Id, vm => vm.MapFrom(m => m.Id))
                .ForMember(p => p.ProductCode, vm => vm.MapFrom(m => m.ProductCode))
                .ForMember(p => p.Name, vm => vm.MapFrom(m => m.Name))
                .ForMember(p => p.Description, vm => vm.MapFrom(m => m.Description))
                .ForMember(p => p.CategoryId, vm => vm.MapFrom(m => m.CategoryId))
                .ForMember(p => p.ManufacturerId, vm => vm.MapFrom(m => m.ManufacturerId))
                .ForMember(p => p.Price, vm => vm.MapFrom(m => m.Price))
                .ForMember(p => p.StockQuantity, vm => vm.MapFrom(m => m.StockQuantity));
            
            this.CreateMap<Product, ProductBindingModel>()
                .ForMember(p => p.Id, vm => vm.MapFrom(m => m.Id))
                .ForMember(p => p.ProductCode, vm => vm.MapFrom(m => m.ProductCode))
                .ForMember(p => p.Name, vm => vm.MapFrom(m => m.Name))
                .ForMember(p => p.Description, vm => vm.MapFrom(m => m.Description))
                .ForMember(p => p.Category, vm => vm.MapFrom(m => m.CategoryId))
                .ForMember(p => p.Manufacturer, vm => vm.MapFrom(m => m.ManufacturerId))
                .ForMember(p => p.Price, vm => vm.MapFrom(m => m.Price))
                .ForMember(p => p.StockQuantity, vm => vm.MapFrom(m => m.StockQuantity));
        }
    }
}