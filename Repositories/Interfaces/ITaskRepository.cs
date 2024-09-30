using TaskSystemAPIBackEnd.Models;

namespace TaskSystemAPIBackEnd.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task, int id);
        Task<bool> Delete(int id);
    }
}
