using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Basket : Entity
    {
        public int IdPrice { get; set; }

        public int PassengersNumber { get; set; }

        public int IdUser { get; set; }

        public DateTime ReservationDate { get; set; }


        public virtual Price Price { get; set; }
        public virtual User User { get; set; }

    }
}
