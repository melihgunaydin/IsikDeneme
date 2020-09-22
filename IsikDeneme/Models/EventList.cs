using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsikDeneme.Models
{
    public class EventList
    {
        public int Id { get; set; }
        public int EventTypeId { get; set; }
        public string EventName { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
