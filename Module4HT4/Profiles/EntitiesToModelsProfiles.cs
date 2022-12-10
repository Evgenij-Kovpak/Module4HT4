using AutoMapper;
using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Profiles
{
    public class EntitiesToModelsProfiles : Profile
    {
        public EntitiesToModelsProfiles()
        {
            CreateMap<CategoryEntity, Category>();
            CreateMap<CustomerEntity, Customer>();
            CreateMap<OrderEntity, Order>();
            CreateMap<OrderDetailsEntity, OrderDetails>();
            CreateMap<PaymentEntity, Payment>();
            CreateMap<ProductEntity, Product>();
            CreateMap<ShipperEntity, Shipper>();
            CreateMap<SupplierEntity, Supplier>();
        }
    }
}
