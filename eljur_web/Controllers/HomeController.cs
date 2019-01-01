using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eljur_web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var count =  source.Count(); // CountAsync();
            var items =  source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Events = items
            };
            return View(viewModel);
        }




    }


}
