using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Price : Entity
    {
        public decimal PriceValue { get; set; }

        public DateTime DateFrom { get; set; }

        public int IdTimetabe { get; set; }


        public virtual Timetable Timetable { get; set; }


        public virtual IEnumerable<Basket> Baskets { get; set; } = new HashSet<Basket>();
    }
}
