using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.CityQueries;
using AutoMapper;
using DataAccess;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.CityQueries
{
    public class EFGetCityQuery : IGetCityQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetCityQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Get city";

        public CityDto Execute(int search)
        {
            var city = _context.Cities.Include(x=>x.Country).FirstOrDefault(x=>x.Id==search);

            if (city == null)
            {
                throw new EntityNotFoundException(search, typeof(City));
            }

            return _mapper.Map<CityDto>(city);
        }
    }
}
