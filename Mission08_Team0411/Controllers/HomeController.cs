using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
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
            var tasks = _repo.GetTasksWithCategories().ToList();
            
            // Debugging output (since we keep having so many errors)
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task.TaskName}, Category: {task.Category?.CategoryName ?? "No Category"}");
            }
            
            // Ensure model is never null
            if (tasks == null || !tasks.Any())
            {
                tasks = new List<ToDo>(); // returns empty list instead of null
            }
            
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

            ViewBag.Categories = _repo.GetCategories()
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Add_Edit", recordToEdit);

        }

        // post route to edit and update a task into the database
        [HttpPost]
        public IActionResult Edit(ToDo updatedInfo)
        {
            _repo.Update(updatedInfo);
            _repo.SaveChanges(updatedInfo);
            return RedirectToAction("Index");
        }

        // Add Action
        [HttpGet]
        public IActionResult Add_Edit()
        {
            ViewBag.Categories = _repo.Categories
                .ToList();
            return View("Add_Edit", new ToDo());
        }

        [HttpPost]
        public IActionResult Add_Edit(ToDo response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);
            }
            
            return RedirectToAction("Index");
        }
        
        
        
        // get route for the delete action that takes in the taskId
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo
                .GetTasksWithCategories()
                .Single(task => task.TaskId == id);

            
            return View("DeleteConfirmation", recordToDelete);
        }

        // post route that takes a task and deletes it
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var taskToDelete = _repo.Tasks
                .Single(task => task.TaskId == id);

            if (taskToDelete != null)
            {
                _repo.DeleteTask(taskToDelete);
            }

            return RedirectToAction("Index");
        }
    }

}
