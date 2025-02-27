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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Category
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Add_Edit", recordToEdit);

        }

        // post route to edit and update a task into the database
        [HttpPost]
        public IActionResult Edit(ToDo updatedInfo)
        {
            _repo.Update(updatedInfo);
            return RedirectToAction("Index");
        }

        // get route for the delete action that takes in the taskId
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View("Delete");
        }

        // post route that takes a task and deletes it
        [HttpPost]
        public IActionResult Delete(ToDo t)
        {
            _repo.Tasks.Remove(t);
            _repo.SaveChanges(t);

            return RedirectToAction("DeleteConfirmation");
        }
    }

}
