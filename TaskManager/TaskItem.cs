namespace TaskManager
{
    public class TaskItem
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string description)
        {
            Description = description;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"{Description} [{(IsCompleted ? "Completed" : "Pending")}]";
        }
    }
}