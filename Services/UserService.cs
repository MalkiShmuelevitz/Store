using Entities;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _iuserRepository;

        public UserService(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        public async Task<User> GetById(int id)
        {
            return await _iuserRepository.GetById(id);
        }

        public Task<User> PostLoginS(string username, string password)
        {

            return _iuserRepository.PostLoginR(username, password);
        }
        public Task<User> Post(User user)
        {

            return _iuserRepository.Post(user);
        }

        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
        public  async Task Put(int id, User user)
        {
          await  _iuserRepository.Put(id, user);
        }
    }
}
