using AutoMapper;
using WebHosting.EntityLayer.DTO;
using WebHosting.EntityLayer.Entities;

namespace WebHostingAPI.Helper
{
    public class HostingProfile:Profile
    {
        public HostingProfile()
        {
            CreateMap<Hosting, HostingDetailDto>().ReverseMap();
            CreateMap<Hosting, HostingDto>().ReverseMap();
        }
    }
}
