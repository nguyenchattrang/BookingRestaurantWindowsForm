using System;
using System.Collections.Generic;

#nullable disable

namespace Booking_Restaurant.Models
{
    public partial class Time
    {
        public Time()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Time1 { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
