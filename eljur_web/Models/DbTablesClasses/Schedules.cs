using System;
using System.Collections.Generic;

namespace eljur_web.Models
{
    public partial class Schedules
    {
        public int ScheduleId { get; set; }
        public string Clas { get; set; }
        public TimeSpan StartTimeLessons { get; set; }
        public TimeSpan EndTimeLessons { get; set; }
    }
}
