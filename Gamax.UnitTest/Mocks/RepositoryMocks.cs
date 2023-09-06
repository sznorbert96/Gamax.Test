using Gamax.Application.Contracts.Persistence;
using Gamax.Domain.Entities;
using Moq;

namespace Gamax.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var user1Guid = Guid.Parse(Guid.NewGuid().ToString());
            var user2Guid = Guid.Parse(Guid.NewGuid().ToString());
            var user3Guid = Guid.Parse(Guid.NewGuid().ToString());

            var users = new List<User>()
            {
                new User
                {
                    UserId = user1Guid,
                    BirthDate = DateTime.Parse("1996.08.12"),
                    CreatedBy = "system",
                    CreatedDate = DateTime.Parse("2023.09.06"),
                    Email = "user1@gmail.com",
                    FirstName = "UserFirstName1",
                    LastName = "UserLastName1",
                    Password = "user1"
                },
                new User
                {
                    UserId = user2Guid,
                    BirthDate = DateTime.Parse("1976.02.22"),
                    CreatedBy = "system",
                    CreatedDate = DateTime.Parse("2023.09.06"),
                    Email = "user2@gmail.com",
                    FirstName = "UserFirstName2",
                    LastName = "UserLastName2",
                    Password = "user2"
                },
                new User
                {
                    UserId = user3Guid,
                    BirthDate = DateTime.Parse("1981.06.07"),
                    CreatedBy = "system",
                    CreatedDate = DateTime.Parse("2023.09.06"),
                    Email = "user3@gmail.com",
                    FirstName = "UserFirstName3",
                    LastName = "UserLastName3",
                    Password = "user3"
                }
            };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(users);

            mockUserRepository.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                users.Add(user);
                return user;
            });

            return mockUserRepository;
        }
    }
}
