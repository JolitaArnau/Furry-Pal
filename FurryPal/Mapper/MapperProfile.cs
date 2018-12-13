using AutoMapper;
using FurryPal.Models;
using FurryPal.Web.Areas.Admin.ViewModels.Categories;
using FurryPal.Web.Areas.Admin.ViewModels.Manufacturers;
using FurryPal.Web.Areas.Admin.ViewModels.Products;
using FurryPal.Web.Areas.Admin.ViewModels.Users;
using FurryPal.Web.ViewModels.Products;

namespace FurryPal.Web.Mapper
{
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
                .ForMember(p => p.CategoryName, vm => vm.MapFrom(m => m.Category.Name))
                .ForMember(p => p.ManufacturerName, vm => vm.MapFrom(m => m.Manufacturer.Name))
                .ForMember(p => p.Price, vm => vm.MapFrom(m => m.Price))
                .ForMember(p => p.StockQuantity, vm => vm.MapFrom(m => m.StockQuantity))
                .ForMember(p => p.ImageUrl, vm => vm.MapFrom(m => m.ImageUrl));
            
            this.CreateMap<Product, ProductBindingModel>()
                .ForMember(p => p.Id, vm => vm.MapFrom(m => m.Id))
                .ForMember(p => p.ProductCode, vm => vm.MapFrom(m => m.ProductCode))
                .ForMember(p => p.Name, vm => vm.MapFrom(m => m.Name))
                .ForMember(p => p.Description, vm => vm.MapFrom(m => m.Description))
                .ForMember(p => p.Category, vm => vm.MapFrom(m => m.Category.Name))
                .ForMember(p => p.Manufacturer, vm => vm.MapFrom(m => m.Manufacturer.Name))
                .ForMember(p => p.Price, vm => vm.MapFrom(m => m.Price))
                .ForMember(p => p.StockQuantity, vm => vm.MapFrom(m => m.StockQuantity))
                .ForMember(p => p.ImageUrl, vm => vm.MapFrom(m => m.ImageUrl))
                .ForMember(p => p.Keywords, vm => vm.MapFrom(m => m.Keywords));

            this.CreateMap<Product, AllProductsByCategoryViewModel>()
                .ForMember(p => p.Name, vm => vm.MapFrom(m => m.Name))
                .ForMember(p => p.ImageUrl, vm => vm.MapFrom(m => m.ImageUrl))
                .ForMember(p => p.ManufacturerName, vm => vm.MapFrom(m => m.Manufacturer.Name));
            
            this.CreateMap<User, UserViewModel>()
                .ForMember(uvm => uvm.Id, x => x.MapFrom(u => u.Id))
                .ForMember(uvm => uvm.Username, x => x.MapFrom(u => u.UserName));

        }
    }
}