using Application.DataTransfer;
using Application.Queries;
using Application.Queries.TimetableQueries;
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

namespace Implementation.Queries.TimetableQueries
{
    public class EFGetTimetablesQuery : IGetTimetablesQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetTimetablesQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Get timetables";

        public PagedResponse<TimetableDto> Execute(SearchTimetableDto search)
        {
            var timetables = _context.Timetables.Include(x => x.Destination).ThenInclude(x => x.CityFrom)
                                                .Include(x => x.Destination).ThenInclude(x => x.CityTo)
                                                .Include(x => x.Prices).AsQueryable();

            if (!string.IsNullOrEmpty(search.From))
            {
                timetables = timetables.Where(x => x.Destination.CityFrom.Name.Contains(search.From));
            }

            if (!string.IsNullOrEmpty(search.To))
            {
                timetables = timetables.Where(x => x.Destination.CityTo.Name.Contains(search.To));
            }




            return timetables.Paged<TimetableDto, Timetable>(search, _mapper);
        }
    }
}
