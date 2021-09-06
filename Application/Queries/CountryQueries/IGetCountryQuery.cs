using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.CountryQueries
{
    public interface IGetCountryQuery : IQuery<int, CountryDto>
    {
    }
}
