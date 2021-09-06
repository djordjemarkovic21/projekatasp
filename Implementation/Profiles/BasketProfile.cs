using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>()
                .ForMember(dto => dto.Price, opt => opt.MapFrom(opt => opt.Price.PriceValue))
                .ForMember(dto => dto.From, opt => opt.MapFrom(opt => opt.Price.Timetable.Destination.CityFrom.Name))
                .ForMember(dto => dto.To, opt => opt.MapFrom(opt => opt.Price.Timetable.Destination.CityTo.Name));

            CreateMap<BasketDto, Basket>();
        }
    }
}
