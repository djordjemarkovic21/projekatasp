using Application.DataTransfer;
using Application.Queries;
using Application.Queries.CountryQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domen;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.CountryQueries
{
    public class EFGetCountriesQuery : IGetCountriesQuery
    {

        private readonly Context _context;
       private readonly IMapper _mapper;

        public EFGetCountriesQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Search countries";

        public PagedResponse<CountryDto> Execute(SearchCountryDto search)
        {
            var countries = _context.Countries.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                countries = countries.Where(x => x.Name.Contains(search.Keyword));
            }



            return countries.Paged<CountryDto, Country>(search, _mapper);
        }
    }
}
