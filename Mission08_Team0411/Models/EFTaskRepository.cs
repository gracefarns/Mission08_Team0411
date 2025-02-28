using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0411.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TasksContext _context;
        public EFTaskRepository(TasksContext temp)
        {
            _context = temp;
        }

        public List<ToDo> Tasks => _context.Tasks.ToList();


        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(ToDo toDo)
        {
            _context.Add(toDo);
            _context.SaveChanges();
        }

        public void SaveChanges(ToDo toDo)
        {
            _context.SaveChanges();
        }

        public void Update(ToDo toDo)
        {
            _context.Tasks.Update(toDo);
            _context.SaveChanges();
        }
        
        // Implement GetCategories() method
        public List<Category> GetCategories()
        {
            return _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
        }
        
        // Implement GetTasksWithCategories() method
        public IQueryable<ToDo> GetTasksWithCategories()
        {
            return _context.Tasks
                .Include(t => t.Category);
        }
        
        // Create new method
        public void DeleteTask(ToDo toDo)
        {
            _context.Tasks.Remove(toDo);
            _context.SaveChanges();
        }
    }
}
