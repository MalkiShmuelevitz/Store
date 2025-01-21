using Entities;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        //string path = "M:/Store/Repositories/users.txt";
        ManagerApiContext _managerApiContext;

        public UserRepository(ManagerApiContext managerApiContext)
        {
           _managerApiContext = managerApiContext;
        }

        public async Task<User> PostLoginR(string username, string password)
        {
            //await managerApiContext.AddAsync(username, password);
            User user = new();
            return user;
        }
        public async Task<User> Post(User user)
        {
           await _managerApiContext.Users.AddAsync(user);
           await _managerApiContext.SaveChangesAsync();
            return user;
        }
        public async void Put(int id,User user1)
        {
            _managerApiContext.Users.Update(user1);
            await _managerApiContext.SaveChangesAsync();

        }
    }
}
