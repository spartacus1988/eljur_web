using System;
using System.Collections.Generic;

namespace eljur_web.Models
{
    public partial class Pupils
    {
        public int PupilId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullFio { get; set; }
        public int PupilIdOld { get; set; }
        public int EljurAccountId { get; set; }
        public string Clas { get; set; }
    }
}
