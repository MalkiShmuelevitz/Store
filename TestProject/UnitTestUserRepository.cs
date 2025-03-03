using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;

namespace TestProject
{
    public class UnitTestUserRepository
    {
        [Fact]
        public async Task GetUserLogin_validate_returnUser()
            {
            var user = new User { UserName = "shani", Password = "Aa12**30Ss#" };
            var mockContext = new Mock<ManagerApiContext>();
            var users = new List<User> { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.PostLoginR(user.UserName, user.Password);

            Assert.Equal(user, result);
            }
    
    }
}