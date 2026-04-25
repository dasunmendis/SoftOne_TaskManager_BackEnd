namespace TaskManager.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.TaskItem>> GetAllAsync();
        Task<Entities.TaskItem?> GetByIdAsync(int id);
        Task AddAsync(Entities.TaskItem task);
        void Update(Entities.TaskItem task);
        void Delete(Entities.TaskItem task);
    }
}
