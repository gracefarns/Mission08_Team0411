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
            _context.Update(toDo);
            _context.SaveChanges();
        }
    }
}
