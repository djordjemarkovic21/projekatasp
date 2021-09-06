using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.TimetableQueries;
using AutoMapper;
using DataAccess;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.TimetableQueries
{
    public class EFGetTimetableQuery : IGetTimetableQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetTimetableQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Get timetable";

        public TimetableDto Execute(int search)
        {
            var timetable = _context.Timetables.Include(x => x.Destination).ThenInclude(x => x.CityFrom)
                                                .Include(x => x.Destination).ThenInclude(x => x.CityTo)
                                                .Include(x => x.Prices).FirstOrDefault(x=>x.Id==search);

            if (timetable == null)
            {
                throw new EntityNotFoundException(search, typeof(Timetable));
            }

            return _mapper.Map<TimetableDto>(timetable);
        }
    }
}
