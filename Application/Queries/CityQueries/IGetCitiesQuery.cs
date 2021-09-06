using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.CityQueries
{
    public interface IGetCitiesQuery : IQuery<SearchCityDto, PagedResponse<CityDto>>
    {
    }
}
