using Application.DataTransfer;
using Application.Queries;
using Application.Queries.CityQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domen;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.CityQueries
{
    public class EFGetCitiesQuery : IGetCitiesQuery
    {

        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetCitiesQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Get cities";

        public PagedResponse<CityDto> Execute(SearchCityDto search)
        {
            var cities=_context.Cities.Include(x => x.Country).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                cities = cities.Where(x => x.Name.Contains(search.Keyword) 
                                    || x.Country.Name.Contains(search.Keyword));
            }


            return cities.Paged<CityDto, City>(search, _mapper);
        }
    }
}
