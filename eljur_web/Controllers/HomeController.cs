using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eljur_web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eljur_web
{
    public class HomeController : Controller
    {

        private readonly StaffDbContext _context;

        public HomeController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Events.ToListAsync());
            return View(_context.Events);
        }


    }


}
