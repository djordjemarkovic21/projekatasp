using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class BasketDto
    {
        public int Id { get; set; }

        public string? From { get; set; }

        public string? To { get; set; }

        public int IdPrice { get; set; }

        public decimal? Price { get; set; }

        public int PassengersNumber { get; set; }

        public DateTime ReservationDate { get; set; }

        public int IdUser { get; set; }
    }
}
