using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.BasketQueries;
using AutoMapper;
using DataAccess;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.BasketQueries
{
    public class EFGetBasketQuery : IGetBasketQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetBasketQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Get basket";

        public BasketDto Execute(int search)
        {
            var baskets = _context.Baskets
                .Include(x => x.Price)
                .ThenInclude(x => x.Timetable)
                .ThenInclude(x => x.Destination)
                .ThenInclude(x => x.CityFrom)
                .Include(x => x.Price)
                .ThenInclude(x => x.Timetable)
                .ThenInclude(x => x.Destination)
                .ThenInclude(x => x.CityTo)
                .FirstOrDefault(x=>x.Id==search);


            if (baskets == null)
            {
                throw new EntityNotFoundException(search, typeof(Basket));
            }

            return _mapper.Map<BasketDto>(baskets);
        }
    }
}
