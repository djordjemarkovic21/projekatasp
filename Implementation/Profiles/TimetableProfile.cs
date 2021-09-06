using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
    public class TimetableProfile : Profile
    {
        public TimetableProfile()
        {
            CreateMap<Timetable, TimetableDto>()
                .ForMember(dto => dto.From, opt => opt.MapFrom(city => city.Destination.CityFrom.Name))
                .ForMember(dto => dto.IdFrom, opt => opt.MapFrom(city => city.Destination.CityFrom.Id))
                .ForMember(dto => dto.To, opt => opt.MapFrom(city => city.Destination.CityTo.Name))
                .ForMember(dto => dto.IdTo, opt => opt.MapFrom(city => city.Destination.CityTo.Id))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(price => price.Prices.Select(x=>x.PriceValue).LastOrDefault()));

            CreateMap<TimetableDto, Timetable>();

        }
    }
}
