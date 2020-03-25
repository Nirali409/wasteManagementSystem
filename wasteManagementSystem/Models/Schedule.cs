using System;
using System.Collections.Generic;

namespace wasteManagementSystem.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan ScheduleTime { get; set; }
    }
}
