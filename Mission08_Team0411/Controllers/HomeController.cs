using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0411.Models;

namespace Mission08_Team0411.Controllers
{
    public class HomeController : Controller
    {
        private readonly TasksContext _context;

        public HomeController(TasksContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var tasks = _context.Tasks
                .Include(t => t.Category).ToList();
            return View(tasks);
        }

    }
}
