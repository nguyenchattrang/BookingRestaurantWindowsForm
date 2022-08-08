using System;
using System.Collections.Generic;

#nullable disable

namespace Booking_Restaurant.Models
{
    public partial class Table
    {
        public Table()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
