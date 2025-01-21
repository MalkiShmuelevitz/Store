﻿using Entities;
using Microsoft.EntityFrameworkCore;
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


        public async Task<User> GetById(int id)
        {
            return await _managerApiContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        }
        public async Task<User> PostLoginR(string username, string password)
        {
           User user = await _managerApiContext.Users.FirstOrDefaultAsync(u=>u.UserName==username&& u.Password==password);
            return user;
        }
        public async Task<User> Post(User user)
        {
          await _managerApiContext.Users.AddAsync(user);
          await _managerApiContext.SaveChangesAsync();
          return user;
        }
        public async Task Put(int id,User user1)
        {
            user1.Id = id;
            _managerApiContext.Users.Update(user1);
            await _managerApiContext.SaveChangesAsync();
          
        }
    }
}
