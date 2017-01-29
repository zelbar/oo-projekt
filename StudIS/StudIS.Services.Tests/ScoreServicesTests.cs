using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.DAL;
using StudIS.DAL.Repositories;
using StudIS.Models.Users;
using Moq;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models;
using System.Collections.Generic;
using StudIS.DAL.Tests;

namespace StudIS.Services.Tests
{
    [TestClass]
    public class ScoreServicesTests
    {

        private INHibernateService _nhs;
        private User student;
        private User administrator;
        public ScoreServicesTests()
        {
            _nhs = new NHibernateService2();


            var userRep = new UserRepository(_nhs);
            var userServices = new UserServices(userRep);
             student = new Student()
            {
                Id = 1,
                Name = "Zlatko",
                Surname = "Hrastić",
                Email = "zlatko.hrastic@fer.hr",
                NationalIdentificationNumber = "343999999",
                StudentIdentificationNumber = "0036476522",
                CoursesEnrolledIn = null,
                PasswordHash = "xxx"

            };

            administrator = new Administrator()
            {
                Id = 2,
                Email = "zeljko@uni.hr",
                PasswordHash = EncryptionService.EncryptSHA1("123abc"),
                Name = "Željko",
                Surname = "Baranek",
                NationalIdentificationNumber = "123456"
            };



        }

        [TestMethod]
        public void GetScorebyStudentAndCourseTest()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();


            var componentList = new List<Component>();
            componentList.Add(new Component());

            Mock<Course> courseMock = new Mock<Course>();
            courseMock.Setup(c => c.Components).Returns(componentList);

            corRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(courseMock.Object);
            usrRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(student);
            scrRepMock.Setup(c => c.GetByStudentIdAndComponentId(It.IsAny<Student>(), It.IsAny<Component>())).Returns(new Score());
            
            var scoreService = new ScoreServices(scrRepMock.Object, corRepMock.Object, usrRepMock.Object);

            var scores = scoreService.GetScorebyStudentAndCourse(1, 1);

            Assert.IsNotNull(scores);
            Assert.IsFalse(scores.Count == 0);

        }

        [TestMethod]
        public void GetScorebyStudentAndCourseTest_DefaultScore()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();


            var componentList = new List<Component>();
            componentList.Add(new Component());

            Mock<Course> courseMock = new Mock<Course>();
            courseMock.Setup(c => c.Components).Returns(componentList);

            corRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(courseMock.Object);
            usrRepMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(student);
            scrRepMock.Setup(c => c.GetByStudentIdAndComponentId(It.IsAny<Student>(), It.IsAny<Component>())).Returns<Score>(null);
            scrRepMock.Setup(c => c.CreateOrUpdate(It.IsAny<Score>())).Returns(new Score() { Value = 0 });

            var scoreService = new ScoreServices(scrRepMock.Object, corRepMock.Object, usrRepMock.Object);

            var scores = scoreService.GetScorebyStudentAndCourse(1, 1);

            Assert.IsNotNull(scores);
            Assert.IsFalse(scores.Count == 0);
            Assert.AreEqual(0, scores[0].Value);

        }
    }
}
