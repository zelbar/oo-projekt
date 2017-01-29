using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Models.Users;
using StudIS.DAL.Repositories;
using StudIS.DAL;
using Moq;
using StudIS.Models.RepositoryInterfaces;
using StudIS.DAL.Tests;

namespace StudIS.Services.Tests
{
    [TestClass]
    public class UserServicesTests
    {
        INHibernateService _nhs;
        public UserServicesTests()
        {
            _nhs = new NHibernateService2();
        }

        [TestMethod]
        public void IsUserAdministrator_True()
        {
            Administrator admin = new Administrator();
            Assert.IsTrue(UserServices.IsUserAdministrator(admin));
        }

        [TestMethod]
        public void IsUserAdministrator_False()
        {
            Student student = new Student();
            Assert.IsFalse(UserServices.IsUserAdministrator(student));
        }


        [TestMethod]
        public void IsUserStudent_True()
        {
            Student student = new Student();
            Assert.IsTrue(UserServices.IsUserStudent(student));


        }

        [TestMethod]
        public void IsUserStudent_False()
        {
            Administrator admin = new Administrator();
            Assert.IsFalse(UserServices.IsUserStudent(admin));
        }



        [TestMethod]
        public void IsUserLecturer_True()
        {
            Lecturer lecturer = new Lecturer();
            Assert.IsTrue(UserServices.IsUserLecturer(lecturer));


        }

        [TestMethod]
        public void IsUserLecturer_False()
        {
            Administrator admin = new Administrator();
            Assert.IsFalse(UserServices.IsUserLecturer(admin));
        }

        [TestMethod]
        public void CreateUser_ReturnsSavedUser()
        {
            var student = new Student()
            {

                Name = "Zlatko",
                Surname = "Hrastić",
                Email = "zlatko.hrastic@fer.hr",
                NationalIdentificationNumber = "343999999",
                StudentIdentificationNumber = "0036476522",
                CoursesEnrolledIn = null,
                PasswordHash = "xxx"

            };

            Mock<IUserRepository> usrRep = new Mock<IUserRepository>();
            usrRep.Setup(r => r.Create(It.IsAny<User>())).Returns(student);

           
            var userServices = new UserServices(usrRep.Object);


            var saved = userServices.CreateUser(student);

            Assert.IsNotNull(saved);
            Assert.IsNotNull(saved.Id);
        }
    }
}
