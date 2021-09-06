using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class SearchDestinationDto : PagedSearch
    {
        public int? DurationMin { get; set; }

        public int? DurationMax { get; set; }
    }
}
