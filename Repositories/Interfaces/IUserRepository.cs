using TaskSystemAPIBackEnd.Models;

namespace TaskSystemAPIBackEnd.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
