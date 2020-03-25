using System;
using System.Collections.Generic;

namespace wasteManagementSystem.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int EventUserId { get; set; }
        public int EventTypeId { get; set; }
        public string EventName { get; set; }
    }
}
