using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IsikDeneme.Models;
using System.Data.Entity;

namespace IsikDeneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskDbContext _context;
        private object context;

        public HomeController(ILogger<HomeController> logger,
            TaskDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<EventType> GetEventTypeList()
        {
            return _context.EventTypes.ToList();
        }

        public IActionResult PostEvent([FromForm]EventList _event)
        {
            using (_context)
            {
                var addedEntity = _context.Entry(_event);
                addedEntity.State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Added;
                _context.SaveChanges();
            }
            return Ok();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
