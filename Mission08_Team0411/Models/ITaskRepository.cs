namespace Mission08_Team0411.Models
{
    public interface ITaskRepository
    {
        List<ToDo> Tasks { get; }

        public void AddTask(ToDo toDo);

        public void SaveChanges(ToDo toDo);

        public void Update(ToDo toDo);
    }
}
