using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class SearchTimetableDto : PagedSearch
    {

        public string From { get; set; }

        public string To { get; set; }


        public DateTime Date { get; set; }

    }
}
