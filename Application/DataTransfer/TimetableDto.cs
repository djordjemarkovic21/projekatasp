using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class TimetableDto
    {
        public int Id { get; set; }

        public int IdDestination { get; set; }

        public int IdFrom { get; set; }

        public string From { get; set; }

        public int IdTo { get; set; }

        public string To { get; set; }

        public decimal Price { get; set; }

        public DateTime DepartureDate { get; set; }
    }
}
