using FurryPal.Web.ViewModels.AutoShipping;
using FurryPal.Web.ViewModels.Orders;

namespace FurryPal.Web.Mapper
{
    using AutoMapper;
    using FurryPal.Models;
    using FurryPal.Web.Areas.Admin.ViewModels.Categories;
    using FurryPal.Web.Areas.Admin.ViewModels.Manufacturers;
    using FurryPal.Web.Areas.Admin.ViewModels.Products;
    using FurryPal.Web.Areas.Admin.ViewModels.Users;
    using ViewModels.Checkout;
    using ViewModels.Products;

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

            this.CreateMap<User, UserTryCheckOutBindingModel>()
                .ForMember(u => u.ZipCode, x => x.MapFrom(a => a.Address.ZipCode))
                .ForMember(u => u.CountryName, x => x.MapFrom(a => a.Address.CountryName))
                .ForMember(u => u.CityName, x => x.MapFrom(a => a.Address.CityName))
                .ForMember(u => u.StreetName, x => x.MapFrom(a => a.Address.StreetName))
                .ForMember(u => u.HouseNumber, x => x.MapFrom(a => a.Address.HouseNumber))
                .ForMember(u => u.Purchases, x => x.MapFrom(p => p.Purchases));

            this.CreateMap<Purchase, YourOrdersViewModel>()
                .ForMember(p => p.IsBought, x => x.MapFrom(y => y.IsBought))
                .ForMember(p => p.OrderDate, x => x.MapFrom(y => y.OrderDate))
                .ForMember(p => p.TotalOrderPrice, x => x.MapFrom(y => y.TotalOrderPrice))
                .ForMember(p => p.ProductPurchases, x => x.MapFrom(y => y.ProductPurchases));
            
            this.CreateMap<AutoShippingPurchase, AutoShippingPurchasesViewModel>()
                .ForMember(p => p.NextReorderDispatchDate, x => x.MapFrom(y => y.NextReorderDispatchDate))
                .ForMember(p => p.TotalOrderPrice, x => x.MapFrom(y => y.TotalOrderPrice))
                .ForMember(p => p.ProductPurchases, x => x.MapFrom(y => y.ProductPurchases));
        }
    }
}