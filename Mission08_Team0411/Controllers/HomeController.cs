using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0411.Models;

namespace Mission08_Team0411.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;
        public HomeController(ITaskRepository temp) // make sure that this matches the context file camden made
        {
            _repo = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = _repo.Tasks.ToList();
            // this would be for editing var blah = _repo.Tasks.FirstOrDefault(x => x.TaskId == 1);
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Index(ToDo t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
            }
            var tasks = _repo.Tasks.ToList();
            return View(tasks);
        }
    }

}
