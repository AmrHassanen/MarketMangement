using AutoMapper;
using MarketMangement.Entity.Models;
using MarketMangement.MVC.DTOs;
using MarketMangement.Service.DTOs;

namespace MarketMangement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create mapping between Property (from MarketMangement.Entity.Models) and PropertyDto
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<PropertyItem, PropertyItemDto>().ReverseMap();
            CreateMap<DeviceCategory, DeviceCategoryDto>().ReverseMap();

        }
    }
}
