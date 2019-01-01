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

        public async Task<IActionResult> Index(int page = 1, SortState sortOrder = SortState.EventIdAsc)
        {
            int pageSize = 10;   // количество элементов на странице

            IQueryable<Events> source = _context.Events;
            IQueryable<Pupils> sourcePupils = _context.Pupils;

            // sorting
            switch (sortOrder)
            {
                case SortState.EventIdDesc:
                    source = source.OrderByDescending(s => s.EventId);
                    break;
                case SortState.EventNameAsc:
                    source = source.OrderBy(s => s.EventName);
                    break;
                case SortState.EventNameDesc:
                    source = source.OrderByDescending(s => s.EventName);
                    break;
                case SortState.NotifyEnableAsc:
                    source = source.OrderBy(s => s.NotifyEnable);
                    break;
                case SortState.NotifyEnableDesc:
                    source = source.OrderByDescending(s => s.NotifyEnable);
                    break;
                case SortState.NotifyWasSendAsc:
                    source = source.OrderBy(s => s.NotifyWasSend);
                    break;
                case SortState.NotifyWasSendDesc:
                    source = source.OrderByDescending(s => s.NotifyWasSend);
                    break;
                case SortState.EventTimeAsc:
                    source = source.OrderBy(s => s.EventTime);
                    break;
                case SortState.EventTimeDesc:
                    source = source.OrderByDescending(s => s.EventTime);
                    break;
                case SortState.PupilIdOldAsc:
                    source = source.OrderBy(s => s.PupilIdOld);
                    break;
                case SortState.PupilIdOldDesc:
                    source = source.OrderByDescending(s => s.PupilIdOld);
                    break;
                case SortState.EljurAccountIdAsc:
                    sourcePupils = sourcePupils.OrderBy(s => s.EljurAccountId);
                    break;
                case SortState.EljurAccountIdDesc:
                    sourcePupils = sourcePupils.OrderByDescending(s => s.EljurAccountId);
                    break;
                case SortState.FullFioAsc:
                    sourcePupils = sourcePupils.OrderBy(s => s.FullFio);
                    break;
                case SortState.FullFioDesc:
                    sourcePupils = sourcePupils.OrderByDescending(s => s.FullFio);
                    break;
                case SortState.ClasAsc:
                    sourcePupils = sourcePupils.OrderBy(s => s.Clas);
                    break;
                case SortState.ClasDesc:
                    sourcePupils = sourcePupils.OrderByDescending(s => s.Clas);
                    break;
                default:
                    source = source.OrderBy(s => s.EventId);
                    break;
            }
            //pagenation
            var list =  source.ToList();
            var count =  source.Count(); 
            var items =  source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            
            var map = new Dictionary<Events, Pupils>();
            //map.Add("cat", "orange");
            foreach (Events e in items)
            {              
                Pupils p = _context.Pupils.SingleOrDefault(pup => pup.PupilIdOld == e.PupilIdOld);
                map.Add(e, p);
            }


            //PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                //PageViewModel = pageViewModel,
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                Events = items,
                mapEventsPupils = map
            };
            return View(viewModel);
        }




    }


}
