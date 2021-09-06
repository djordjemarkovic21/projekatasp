using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.DestinationQueries;
using AutoMapper;
using DataAccess;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.DestinationQueries
{
    public class EFGetDestinationQuery : IGetDestinationQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetDestinationQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Get destination";

        public DestinationDto Execute(int search)
        {
            var destination = _context.Destinations
                            .Include(x => x.CityFrom)
                            .Include(x => x.CityTo)
                            .FirstOrDefault(x=>x.Id==search);

            if (destination == null)
            {
                throw new EntityNotFoundException(search, typeof(Destination));
            }

            return _mapper.Map<DestinationDto>(destination);
        }
    }
}
