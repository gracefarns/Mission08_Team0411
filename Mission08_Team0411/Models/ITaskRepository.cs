namespace Mission08_Team0411.Models
{
    public interface ITaskRepository
    {
        List<ToDo> Tasks { get; }

        public void AddTask(ToDo toDo);
    }
}
