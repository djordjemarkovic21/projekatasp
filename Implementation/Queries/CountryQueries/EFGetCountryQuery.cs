using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.CountryQueries;
using AutoMapper;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries.CountryQueries
{
    public class EFGetCountryQuery : IGetCountryQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetCountryQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "One country";

        public CountryDto Execute(int search)
        {
            var country = _context.Countries.Find(search);

            if (country == null)
            {
                throw new EntityNotFoundException(search, typeof(Country));
            }

            return _mapper.Map<CountryDto>(country);
        }
    }
}
