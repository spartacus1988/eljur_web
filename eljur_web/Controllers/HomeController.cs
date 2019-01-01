using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eljur_web.Models;


namespace eljur_web.Controllers
{
    public class HomeController : Controller
    {

        private readonly StaffDbContext _context;

        public HomeController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Indexxx()
        {
            //return View(await _context.Events.ToListAsync());
            return View(_context.Events);
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;   // количество элементов на странице

            IQueryable<Events> source = _context.Events;
            var list =  source.ToList();
            var count =  source.Count(); 
            var items =  source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            IQueryable<Pupils> sourcePupils = _context.Pupils;
            var map = new Dictionary<Events, Pupils>();
            //map.Add("cat", "orange");
            foreach (Events e in items)
            {              
                Pupils p = _context.Pupils.SingleOrDefault(pup => pup.PupilIdOld == e.PupilIdOld);
                map.Add(e, p);
            }


            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Events = items,
                mapEventsPupils = map
            };
            return View(viewModel);
        }




    }


}
