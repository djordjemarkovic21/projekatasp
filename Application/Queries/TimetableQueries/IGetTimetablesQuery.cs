using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.TimetableQueries
{
    public interface IGetTimetablesQuery : IQuery<SearchTimetableDto, PagedResponse<TimetableDto>>
    {
    }
}
