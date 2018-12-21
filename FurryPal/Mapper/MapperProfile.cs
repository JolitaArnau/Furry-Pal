using AutoMapper;
using FurryPal.Models;
using FurryPal.Web.Areas.Admin.ViewModels.Categories;
using FurryPal.Web.Areas.Admin.ViewModels.Manufacturers;
using FurryPal.Web.Areas.Admin.ViewModels.Products;
using FurryPal.Web.Areas.Admin.ViewModels.Users;
using FurryPal.Web.ViewModels.Cart;
using FurryPal.Web.ViewModels.Products;

namespace FurryPal.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Category, AllCategoriesViewModel>();

            this.CreateMap<Category, EditDeleteCategoryViewModel>();

            this.CreateMap<Manufacturer, AllManufacturersViewModel>();

            this.CreateMap<Manufacturer, EditDeleteManufacturerViewModel>();

            this.CreateMap<Product, AllProductsViewModel>()
                .ForMember(p => p.CategoryName, vm => vm.MapFrom(m => m.Category.Name))
                .ForMember(p => p.ManufacturerName, vm => vm.MapFrom(m => m.Manufacturer.Name));

            this.CreateMap<Product, ProductBindingModel>()
                .ForMember(p => p.Category, vm => vm.MapFrom(m => m.Category.Name))
                .ForMember(p => p.Manufacturer, vm => vm.MapFrom(m => m.Manufacturer.Name));

            this.CreateMap<Product, ProductOverviewViewModel>()
                .ForMember(p => p.ManufacturerName, vm => vm.MapFrom(m => m.Manufacturer.Name));

            this.CreateMap<Product, ProductDetailViewModel>()
                .ForMember(p => p.ManufacturerName, vm => vm.MapFrom(m => m.Manufacturer.Name));       
            
            this.CreateMap<User, UserViewModel>()
                .ForMember(uvm => uvm.Id, x => x.MapFrom(u => u.Id))
                .ForMember(uvm => uvm.Username, x => x.MapFrom(u => u.UserName));

            //this.CreateMap<Product, ShoppingCartViewModel>();

        }
    }
}