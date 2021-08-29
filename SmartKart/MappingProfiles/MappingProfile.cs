using AutoMapper;
using SmartCart.Repo.Model;
using SmartKart.Models;

namespace SmartKart.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderItemModel,OrderItems>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<ItemsModel, Item>().ReverseMap();
        }
    }
}
