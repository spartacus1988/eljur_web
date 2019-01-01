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


        public IndexViewModel()
        {
            
        }

        public Pupils getPupilDataByEvent(Events e)
        {
            using (this.StaffCtx = new StaffDbContext())
            {
                //foreach (Events e in Events)
                //{
                Pupils pupil = StaffCtx.Pupils.SingleOrDefault(p => p.PupilIdOld == e.PupilIdOld);
                //}
                return pupil;
            }           

        }
    }
}   