using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Models.RepositoryInterfaces;
using Moq;
using StudIS.Models.Users;

namespace StudIS.Services.Tests
{
    [TestClass]
    public class LoginServiceTest
    {
        [TestMethod]
        public void LoginUserTest_Correct()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            usrRepMock.Setup(c => c.GetByEmail(It.IsAny<string>())).Returns(new Student() { PasswordHash = "xxx" });

            var service = new LoginService(usrRepMock.Object);
            var result = service.LoginUser("testUser", "xxx");

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void LoginUserTest_InCorrect()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            usrRepMock.Setup(c => c.GetByEmail(It.IsAny<string>())).Returns(new Student() { PasswordHash = "xxx" });

            var service = new LoginService(usrRepMock.Object);
            var result = service.LoginUser("testUser", "yyy");

            Assert.IsNull(result);
        }


        [TestMethod]
        public void LoginUserTest_NonExistantUser()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            usrRepMock.Setup(c => c.GetByEmail(It.IsAny<string>())).Returns<User>(null);

            var service = new LoginService(usrRepMock.Object);
            var result = service.LoginUser("testUser", "yyy");

            Assert.IsNull(result);
        }
    }
}
