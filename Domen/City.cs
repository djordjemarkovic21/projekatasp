using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class City : Entity
    {
        public string Name { get; set; }

        public int IdCountry { get; set; }


        public virtual Country Country { get; set; }


        public virtual IEnumerable<Destination> DestinationsFrom { get; set; } = new HashSet<Destination>();


        public virtual IEnumerable<Destination> DestinationsTo { get; set; } = new HashSet<Destination>();
    }
}
