using System.Collections.Generic;
using System.Linq;

namespace eljur_web.Models
{
    public class IndexViewModel
    {
        public Dictionary<Events, Pupils> mapEventsPupils { get; set; }
        public IEnumerable<Events> Events { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public StaffDbContext StaffCtx { get; set; }
        public SortViewModel SortViewModel { get; set; }


        public IndexViewModel()
        {
            
        }


    }
}   