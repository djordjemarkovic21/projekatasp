using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.CountryQueries
{
    public interface IGetCountriesQuery : IQuery<SearchCountryDto, PagedResponse<CountryDto>>
    {
    }
}
