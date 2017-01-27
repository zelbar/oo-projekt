using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.DAL;
using StudIS.DAL.SQL;
using StudIS.Models.Users;
using StudIS.DAL.Repositories;

namespace StudIS.Services.Tests
{
    [TestClass]
    public class StudentServicesTests
    {
        private INHibernateService _nhs;
        public StudentServicesTests()
        {
            _nhs = new NHibernateService2();


            var userRep = new UserRepository(_nhs);
            var userServices = new UserServices(userRep);
            var student = new Student()
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

            var administrator = new Administrator()
            {
                Id = 2,
                Email = "zeljko@uni.hr",
                PasswordHash = EncryptionService.EncryptSHA1("123abc"),
                Name = "Željko",
                Surname = "Baranek",
                NationalIdentificationNumber = "123456"
            };

            userServices.createUser(student);
            userServices.createUser(administrator);
        }

        [TestMethod]
        public void GetStudentdata_StudentId()
        {
            var userRep = new UserRepository(_nhs);
            var studentServices = new StudentServices(userRep);
            var studentData = studentServices.getStudentdata(1);


            Assert.IsNotNull(studentData);
            Assert.AreEqual(studentData.Id, 1);

        }

        [TestMethod]
        public void GetStudentdata_NotStudentId()
        {
            var userRep = new UserRepository(_nhs);
            var studentServices = new StudentServices(userRep);
            var studentData = studentServices.getStudentdata(2);


            Assert.IsNull(studentData);
         

        }
    }
}
