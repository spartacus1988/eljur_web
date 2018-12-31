using System.Collections.Generic;

namespace eljur_web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Events> Events { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}