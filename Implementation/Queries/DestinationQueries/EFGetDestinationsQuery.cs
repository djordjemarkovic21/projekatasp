using Application.DataTransfer;
using Application.Queries;
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

namespace Implementation.Queries.DestinationQueries
{
    public class EFGetDestinationsQuery : IGetDestinationsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetDestinationsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Get destinations";

        public PagedResponse<DestinationDto> Execute(SearchDestinationDto search)
        {
            var destinations = _context.Destinations.Include(x=>x.CityFrom).Include(x=>x.CityTo).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                destinations = destinations.Where(x => x.CityFrom.Name.Contains(search.Keyword) 
                                                || x.CityTo.Name.Contains(search.Keyword));
            }

            if (search.DurationMin.HasValue)
            {
                destinations = destinations.Where(x => x.Duration >= search.DurationMin);
            }
            if (search.DurationMax.HasValue)
            {
                destinations = destinations.Where(x => x.Duration <= search.DurationMax);
            }

            return destinations.Paged<DestinationDto, Destination>(search, _mapper);
        }
    }
}
