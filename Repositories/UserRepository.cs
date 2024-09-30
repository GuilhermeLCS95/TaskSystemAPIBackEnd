using Microsoft.EntityFrameworkCore;
using TaskSystemAPIBackEnd.Data;
using TaskSystemAPIBackEnd.Models;
using TaskSystemAPIBackEnd.Repositories.Interfaces;

namespace TaskSystemAPIBackEnd.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDbContext _dbContext;
        public UserRepository(TaskSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        

        public async Task<UserModel> Add(UserModel user)
        {
            await  _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userId = await GetById(id);

            if (userId == null)
            {
                throw new Exception("User Id: " + id + " not found.");
            }

            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
      
        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userId = await GetById(id);
            
            if(userId == null)
            {
                throw new Exception("User Id: " + id + " not found.");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;

            _dbContext.Users.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;
        }


    }
}
