using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities
{
    public class TaskItem : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
