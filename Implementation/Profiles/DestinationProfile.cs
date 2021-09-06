using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<Destination, DestinationDto>()
                .ForMember(dto => dto.From, opt => opt.MapFrom(city => city.CityFrom.Name))
                .ForMember(dto => dto.To, opt => opt.MapFrom(city => city.CityTo.Name));


            CreateMap<DestinationDto, Destination>();
        }
    }
}
