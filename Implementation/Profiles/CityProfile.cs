using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>()
                .ForMember(dto => dto.Country, opt => opt.MapFrom(country => country.Country.Name));

            CreateMap<CityDto, City>();
        }
    }
}
