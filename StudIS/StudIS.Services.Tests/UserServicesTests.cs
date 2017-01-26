using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Models.Users;
using StudIS.DAL.Repositories;
using StudIS.DAL.SQL;
using StudIS.DAL;

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
            Assert.IsTrue(UserServices.isUserAdministrator(admin));
        }

        [TestMethod]
        public void IsUserAdministrator_False()
        {
            Student student = new Student();
            Assert.IsFalse(UserServices.isUserAdministrator(student));
        }


        [TestMethod]
        public void IsUserStudent_True()
        {
            Student student = new Student();
            Assert.IsTrue(UserServices.isUserStudent(student));


        }

        [TestMethod]
        public void IsUserStudent_False()
        {
            Administrator admin = new Administrator();
            Assert.IsFalse(UserServices.isUserStudent(admin));
        }



        [TestMethod]
        public void IsUserLecturer_True()
        {
            Lecturer lecturer = new Lecturer();
            Assert.IsTrue(UserServices.isUserLecturer(lecturer));


        }

        [TestMethod]
        public void IsUserLecturer_False()
        {
            Administrator admin = new Administrator();
            Assert.IsFalse(UserServices.isUserLecturer(admin));
        }

        [TestMethod]
        public void CreateUser_ReturnsSavedUser()
        {

            var userRep = new UserRepository(_nhs);
            var userServices = new UserServices(userRep);
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

            var saved = userServices.createUser(student);

            Assert.IsNotNull(saved.Id);
        }
    }
}
