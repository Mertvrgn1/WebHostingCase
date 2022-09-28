using AutoMapper;
using EntityLayer.DTO;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHosting.BusinessLayer.MapperProfiles
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
