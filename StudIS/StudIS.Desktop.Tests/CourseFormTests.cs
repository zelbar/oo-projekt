using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Models.RepositoryInterfaces;
using StudIS.DAL;
using Moq;
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.Services;
using StudIS.DAL.Repositories;
using StudIS.Desktop.Controllers;
using StudIS.DAL.SQL;
using System.Collections.Generic;

namespace StudIS.Desktop.Tests
{
    [TestClass]
    public class CourseFormTests
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IScoreRepository _scoreRepository;

        private readonly UserServices _userServices;
        private readonly CourseServices _courseServices;
        private readonly ScoreServices _scoreServices;

        private static readonly Student student = new Student()
        {
            Email = "eg@example.org",
            PasswordHash = "hash",
            Name = "Sample",
            Surname = "Sample",
            NationalIdentificationNumber = "124",
            StudentIdentificationNumber = "343"
        };
        private static readonly Lecturer lecturer = new Lecturer()
        {
            Email = "eg2@example.org",
            PasswordHash = "hash",
            Name = "Sample2",
            Surname = "Sample2",
            NationalIdentificationNumber = "124"
        };

        private static readonly Course course = new Course()
        {
            Name = "Objektno oblikovanje",
            NaturalIdentifier = "OO-FER-2016",
            EctsCredits = 5,
            StudentsEnrolled = new List<Student>() { student },
            LecturersInCharge = new List<Lecturer>() { lecturer }
        };

        public CourseFormTests()
        {
            var nhs = new NHibernateService2();

            _userRepository = new UserRepository(nhs);
            _courseRepository = new CourseRepository(nhs);
            _componentRepository = new ComponentRepository(nhs);
            _scoreRepository = new ScoreRepository(nhs);

            _userServices = new UserServices(_userRepository);
            _courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);
            _scoreServices = new ScoreServices(_scoreRepository, _courseRepository, _userRepository);
        }

        [TestMethod]
        public void CourseForm_CreateCourse()
        {
            var controller = new UserFormController(_userServices, _courseServices);
            var success = controller.SaveUser(student);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void CourseForm_TryDeleteNonExistingCourse()
        {
            var controller = new CourseFormController(_courseServices, _userServices);
            var success = controller.DeleteCourse(course.Id);

            Assert.IsFalse(success);
        }

        [TestMethod]
        public void CourseForm_TryCreateAndDeleteCourseWithLecturersAndStudents()
        {
            this.CourseForm_CreateCourse();

            var controller = new CourseFormController(_courseServices, _userServices);
            var deletionSuccess = controller.DeleteCourse(course.Id);
            
            Assert.IsFalse(deletionSuccess);
        }
    }
}
