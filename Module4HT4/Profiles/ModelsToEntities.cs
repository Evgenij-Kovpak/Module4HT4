using AutoMapper;
using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Profiles
{
    public class ModelsToEntities : Profile
    {
        public ModelsToEntities()
        {
            CreateMap<Category, CategoryEntity>();
            CreateMap<Customer, CustomerEntity>();
            CreateMap<Order, OrderEntity>();
            CreateMap<OrderDetails, OrderDetailsEntity>();
            CreateMap<Payment, PaymentEntity>();
            CreateMap<Product, ProductEntity>();
            CreateMap<Shipper, ShipperEntity>();
            CreateMap<Supplier, SupplierEntity>();
        }
    }
}
