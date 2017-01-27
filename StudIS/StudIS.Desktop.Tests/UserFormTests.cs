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
        private readonly UserServices _userServices;
        private readonly CourseServices _courseServices;

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
            _userServices = new UserServices(_userRepository);
            _courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);
        }

        [TestMethod]
        public void UserForm_CreateUser()
        {
            var controller = new UserFormController(_userRepository, _courseRepository);
            var success = controller.SaveUser(student);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void UserForm_TryDeleteNonExistingUser()
        {
            var controller = new UserFormController(_userRepository, _courseRepository);
            var success = controller.DeleteUser(student.Email);

            Assert.IsFalse(success);
        }

        [TestMethod]
        public void UserForm_CreateAndDeleteUser()
        {
            this.UserForm_CreateUser();

            var controller = new UserFormController(_userRepository, _courseRepository);
            var deletionSuccess = controller.DeleteUser("eg@example.org");
            
            Assert.IsTrue(deletionSuccess);
        }

        [TestMethod]
        public void UserForm_CreateAndEditUser()
        {
            this.UserForm_CreateUser();

            var controller = new UserFormController(_userRepository, _courseRepository);

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
