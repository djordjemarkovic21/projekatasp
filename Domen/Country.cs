using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Country : Entity
    {
        public string Name { get; set; }

        public virtual IEnumerable<City> Cities { get; set; } = new HashSet<City>();
    }
}
