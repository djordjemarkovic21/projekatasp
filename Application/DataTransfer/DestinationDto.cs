using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class DestinationDto
    {
        public int Id { get; set; }

        public int IdFrom { get; set; }
        public string From { get; set; }

        public int IdTo { get; set; }
        public string To { get; set; }

        public int Duration { get; set; }
    }
}
