using System;
using System.Collections.Generic;

namespace eljur_web.Models
{
    public partial class Events
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public bool NotifyEnable { get; set; }
        public bool NotifyEnableDirector { get; set; }
        public bool NotifyWasSend { get; set; }
        public bool NotifyWasSendDirector { get; set; }
        public TimeSpan EventTime { get; set; }
        public int PupilIdOld { get; set; }
    }
}
