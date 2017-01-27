using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Web.Api.Controllers;
using StudIS.Models.RepositoryInterfaces;
using Moq;
using StudIS.Services;
using StudIS.Models.Users;

namespace StudIS.Web.Api.Tests
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public void Api_LoginTest_Correct()
        {
            var student = new Student()
            {
                Email = "test@test.te",
                PasswordHash = "xxx"
            };

            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            usrRepMock.Setup(u => u.GetByEmail(It.IsAny<string>())).Returns(student);

            var controller = new LoginController(usrRepMock.Object);

            var studentModel=controller.Index("test@test.te", "xxx");

            Assert.IsNotNull(studentModel);
        }


        [TestMethod]
        public void Api_LoginTest_InCorrect()
        {
            var student = new Student()
            {
                Email = "test@test.te",
                PasswordHash = "xxx"
            };

            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            usrRepMock.Setup(u => u.GetByEmail(It.IsAny<string>())).Returns(student);

            var controller = new LoginController(usrRepMock.Object);

            var studentModel = controller.Index("test@test.te", "yyy");

            Assert.IsNull(studentModel);
        }

        [TestMethod]
        public void Api_LoginTest_Admin()
        {
            var administrator = new Administrator()
            {
                Email = "test@test.te",
                PasswordHash = "xxx"
            };

            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            usrRepMock.Setup(u => u.GetByEmail(It.IsAny<string>())).Returns(administrator);

            var controller = new LoginController(usrRepMock.Object);

            var studentModel = controller.Index("test@test.te", "xxx");

            Assert.IsNull(studentModel);
        }
    }
}
