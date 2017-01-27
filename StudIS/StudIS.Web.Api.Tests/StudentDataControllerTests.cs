using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Models.RepositoryInterfaces;
using Moq;
using StudIS.Models.Users;
using StudIS.Web.Api.Controllers;
using StudIS.Models;
using System.Collections.Generic;

namespace StudIS.Web.Api.Tests
{
    [TestClass]
    public class StudentDataControllerTests
    {
        [TestMethod]
        public void Api_GetStudentDataTest_CorrectId()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(new Student());

            var controller = new StudentDataController(usrRepMock.Object, corRepMock.Object, scrRepMock.Object, comRepMock.Object);

            var data =controller.GetStudentData(1);

            Assert.IsNotNull(data);

        }

        [TestMethod]
        public void Api_GetStudentDataTest_InCorrectUserType()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(new Lecturer());

            var controller = new StudentDataController(usrRepMock.Object, corRepMock.Object, scrRepMock.Object, comRepMock.Object);

            var data = controller.GetStudentData(1);

            Assert.IsNull(data);

        }


        [TestMethod]
        public void Api_GetStudentDataTest_InCorrectId()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns<User>(null);

            var controller = new StudentDataController(usrRepMock.Object, corRepMock.Object, scrRepMock.Object, comRepMock.Object);

            var data = controller.GetStudentData(1);

            Assert.IsNull(data);

        }

        [TestMethod]
        public void Api_GetCoursesByStudentIdTest_Correct()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(new Student());

            var courseList = new List<Course>();
            courseList.Add(new Course());


            corRepMock.Setup(c => c.GetByStudentEnroledId(It.IsAny<int>())).Returns(courseList);

            var controller = new StudentDataController(usrRepMock.Object, corRepMock.Object, scrRepMock.Object, comRepMock.Object);

            var data = controller.GetCoursesByStudentId(1);

            Assert.IsNotNull(data);
        }



        [TestMethod]
        public void Api_GetCoursesByStudentIdTest_InCorrectUser()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(new Administrator());

            var courseList = new List<Course>();
            courseList.Add(new Course());


            corRepMock.Setup(c => c.GetByStudentEnroledId(It.IsAny<int>())).Returns(courseList);

            var controller = new StudentDataController(usrRepMock.Object, corRepMock.Object, scrRepMock.Object, comRepMock.Object);

            var data = controller.GetCoursesByStudentId(1);

            Assert.IsNull(data);
        }

        [TestMethod]
        public void Api_GetCoursesByStudentIdTest_NoCourses()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(new Student());

            var courseList = new List<Course>();

            corRepMock.Setup(c => c.GetByStudentEnroledId(It.IsAny<int>())).Returns(courseList);

            var controller = new StudentDataController(usrRepMock.Object, corRepMock.Object, scrRepMock.Object, comRepMock.Object);

            var data = controller.GetCoursesByStudentId(1);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count == 0);
        }
    }
}
