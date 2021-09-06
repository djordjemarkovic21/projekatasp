using Application.DataTransfer;
using Application.Queries;
using Application.Queries.BasketQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domen;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries.BasketQueries
{
    public class EFGetBasketsQuery : IGetBasketsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetBasketsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Get baskets";

        public PagedResponse<BasketDto> Execute(SearchBasketDto search)
        {
            var baskets = _context.Baskets
                .Include(p => p.Price)
                .ThenInclude(t => t.Timetable)
                .ThenInclude(d => d.Destination)
                .ThenInclude(c => c.CityFrom)
                .Include(pr => pr.Price)
                .ThenInclude(ti => ti.Timetable)
                .ThenInclude(de => de.Destination)
                .ThenInclude(ci => ci.CityTo);


            return baskets.Paged<BasketDto, Basket>(search, _mapper);
        }
    }
}
