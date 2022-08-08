using System;
using System.Collections.Generic;

#nullable disable

namespace Booking_Restaurant.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public int? TimeId { get; set; }
        public int? TableId { get; set; }
        public int? Numberofpeople { get; set; }
        public DateTime? Orderdate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Table Table { get; set; }
        public virtual Time Time { get; set; }
    }
}
