namespace Mission08_Team0411.Models
{
    public interface ITaskRepository
    {
        IQueryable<ToDo> Tasks { get; }

        public void AddTask(ToDo toDo);
      
        public void SaveChanges(ToDo toDo);

        public void Update(ToDo toDo);
        
        // Add method to retrieve categories
        List<Category> GetCategories();
        
        // Add method to actually retrieve categories apparently
        IQueryable<ToDo> GetTasksWithCategories();
        
        // Add DeleteTask to interface
        void DeleteTask(ToDo toDo);
    }
}
