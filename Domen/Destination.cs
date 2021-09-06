using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Destination : Entity
    {
        public int IdFrom { get; set; }

        public int IdTo { get; set; }

        public int Duration { get; set; }


        public virtual City CityFrom { get; set; }
        public virtual City CityTo { get; set; }


        public virtual IEnumerable<Price> Prices { get; set; } = new HashSet<Price>();
        public virtual IEnumerable<Timetable> Timetables { get; set; } = new HashSet<Timetable>();
    }
}
