namespace Mission08_Team0411.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TasksContext _context;
        public EFTaskRepository(TasksContext temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();

        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
    }
}
