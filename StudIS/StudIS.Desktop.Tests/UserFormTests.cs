using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Models.RepositoryInterfaces;
using StudIS.DAL;
using Moq;
using StudIS.Models.Users;
using StudIS.Services;
using StudIS.DAL.Repositories;
using StudIS.Desktop.Controllers;
using StudIS.DAL.SQL;

namespace StudIS.Desktop.Tests
{
    [TestClass]
    public class UserFormTests
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IScoreRepository _scoreRepository;

        private readonly UserServices _userServices;
        private readonly CourseServices _courseServices;
        private readonly ScoreServices _scoreServices;

        private readonly Student student = new Student()
        {
            Email = "eg@example.org",
            PasswordHash = "hash",
            Name = "Sample",
            Surname = "Sample",
            NationalIdentificationNumber = "124",
            StudentIdentificationNumber = "343"
        };

        public UserFormTests()
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
        public void UserForm_CreateUser()
        {
            var controller = new UserFormController(_userServices, _courseServices);
            var success = controller.SaveUser(student);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void UserForm_TryDeleteNonExistingUser()
        {
            var controller = new UserFormController(_userServices, _courseServices);
            var success = controller.DeleteUser(student.Email);

            Assert.IsFalse(success);
        }

        [TestMethod]
        public void UserForm_CreateAndDeleteUser()
        {
            this.UserForm_CreateUser();

            var controller = new UserFormController(_userServices, _courseServices);
            var deletionSuccess = controller.DeleteUser("eg@example.org");
            
            Assert.IsTrue(deletionSuccess);
        }

        [TestMethod]
        public void UserForm_CreateAndEditUser()
        {
            this.UserForm_CreateUser();

            var controller = new UserFormController(_userServices, _courseServices);

            var newName = "Pero";
            var newSurname = "Djetlic";
            student.Name = newName;
            student.Surname = newSurname;

            var editSuccess = controller.SaveUser(student);
            var editedUser = _userRepository.GetByEmail(student.Email);

            Assert.IsTrue(editSuccess);
            Assert.AreEqual(newName, editedUser.Name);
            Assert.AreEqual(newSurname, editedUser.Surname);
        }
    }
}
