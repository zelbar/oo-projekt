using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.DAL.Repositories;
using StudIS.DAL.Tests;
using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
using StudIS.Services;
using StudIS.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudIS.Web.Mvc.Tests {

    [TestClass]
    public class LecturerTests {

        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IScoreRepository _scoreRepository;

        private readonly UserServices _userServices;
        private readonly CourseServices _courseServices;
        private readonly ScoreServices _scoreServices;


        private static readonly Student student = new Student() {
            Email = "example@svemir.hr",
            PasswordHash = "hash",
            Name = "Example",
            Surname = "Examply",
            NationalIdentificationNumber = "124",
            StudentIdentificationNumber = "343"
        };
        private static readonly Lecturer lecturer = new Lecturer() {
            Email = "sample@svemir.hr",
            PasswordHash = "hash",
            Name = "Sample",
            Surname = "Samply",
            NationalIdentificationNumber = "124"
        };
        private static readonly Component component = new Component() {
            Id = 534,
            Course = course,
            Name = "Seminari",
            MaximumPoints = 40,
            MinimumPointsToPass = 20

        };
        private static readonly Course course = new Course() {
            Name = "Kvantna računala",
            NaturalIdentifier = "KVARC-FER-2016",
            EctsCredits = 5,
            StudentsEnrolled = new List<Student>() { student },
            LecturersInCharge = new List<Lecturer>() { lecturer },
            Components = new List<Component>() { component }
        };
        public LecturerTests() {
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
        public void LecturerTests_CreateExistingComponent() {
            var controller = new LecturerController(_courseRepository, _scoreRepository, _userRepository, _componentRepository);
            ActionResult success = controller.CreateComponent(component.Id);
            Assert.IsInstanceOfType(success, typeof(ViewResult));
        }
        [TestMethod]
        public void LecturerTests_DeleteExistingComponent() {
            var controller = new LecturerController(_courseRepository, _scoreRepository, _userRepository, _componentRepository);
            var success = controller.DeleteComponent(component.Id, false);
            Assert.IsInstanceOfType(success, typeof(ViewResult));
        }
        [TestMethod]
        public void LecturerTests_DisplayExistingStatistics() {
            var controller = new LecturerController(_courseRepository, _scoreRepository, _userRepository, _componentRepository);
            var success = controller.ComponentStatistics(course.Id);
            Assert.IsInstanceOfType(success, typeof(ViewResult));
        }
        [TestMethod]
        public void LecturerTests_DisplayPersonalData() {
            var controller = new LecturerController(_courseRepository, _scoreRepository, _userRepository, _componentRepository);
            var success = controller.PersonalData();
            Assert.IsInstanceOfType(success, typeof(ViewResult));
        }
        [TestMethod]
        public void LecturerTests_DisplayStudentsEnrolled() {
            var controller = new LecturerController(_courseRepository, _scoreRepository, _userRepository, _componentRepository);
            var success = controller.StudentsEnrolled(course.Id, false);
            Assert.IsInstanceOfType(success, typeof(ViewResult));
        }
        [TestMethod]
        public void LecturerTests_EditComponent() {
            var controller = new LecturerController(_courseRepository, _scoreRepository, _userRepository, _componentRepository);
            var success = controller.EditComponent(component.Id);
            Assert.IsInstanceOfType(success, typeof(ViewResult));
        }
    }
}
