using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
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
            // this would be for editing var blah = _repo.Tasks.FirstOrDefault(x => x.TaskId == 1);
            return View(new Task());
        }

        [HttpPost]
        public IActionResult Index(Task t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
            }
            return View(new Task());
        }
    }

}
