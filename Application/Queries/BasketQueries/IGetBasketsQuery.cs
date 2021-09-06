using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.BasketQueries
{
    public interface IGetBasketsQuery : IQuery<SearchBasketDto, PagedResponse<BasketDto>>
    {
    }
}
