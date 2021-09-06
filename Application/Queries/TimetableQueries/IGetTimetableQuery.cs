using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.TimetableQueries
{
    public interface IGetTimetableQuery : IQuery<int, TimetableDto>
    {
    }
}
