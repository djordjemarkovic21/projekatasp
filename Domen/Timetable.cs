using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Timetable : Entity
    {
        public int IdDestination { get; set; }

        public DateTime DepartureDate { get; set; }


        public virtual Destination Destination { get; set; }


        public virtual IEnumerable<Price> Prices { get; set; } = new HashSet<Price>();
    }
}
