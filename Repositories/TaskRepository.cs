using Microsoft.EntityFrameworkCore;
using TaskSystemAPIBackEnd.Data;
using TaskSystemAPIBackEnd.Models;
using TaskSystemAPIBackEnd.Repositories.Interfaces;

namespace TaskSystemAPIBackEnd.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDbContext _dbContext;
        public TaskRepository(TaskSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks.Include(x=> x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks.Include(x=> x.User).ToListAsync();
        }

        

        public async Task<TaskModel> Add(TaskModel task)
        {
            await  _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskId = await GetTaskById(id);

            if (taskId == null)
            {
                throw new Exception("User Id: " + id + " not found.");
            }

            _dbContext.Tasks.Remove(taskId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
      
        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskId = await GetTaskById(id);
            
            if(taskId == null)
            {
                throw new Exception("Task Id: " + id + " not found.");
            }

            taskId.Name = task.Name;
            taskId.Description = task.Description;
            taskId.Status = task.Status;
            taskId.UserId = task.UserId;

            _dbContext.Tasks.Update(taskId);
            await _dbContext.SaveChangesAsync();

            return taskId;
        }


    }
}
