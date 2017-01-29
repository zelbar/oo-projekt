using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudIS.DAL.Repositories;
using StudIS.DAL.Tests;
using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
using StudIS.Services;
using StudIS.Web.Mvc.Controllers;
using StudIS.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudIS.Web.Mvc.Tests {
    [TestClass]
    public class ComponentTests {
        private static readonly Student student = new Student() {
            Id = 1,
            Email = "example@svemir.hr",
            PasswordHash = "hash",
            Name = "Example",
            Surname = "Examply",
            NationalIdentificationNumber = "124",
            StudentIdentificationNumber = "343"
        };
        private static readonly Lecturer lecturer = new Lecturer() {
            Id = 1,
            Email = "sample@svemir.hr",
            PasswordHash = "hash",
            Name = "Sample",
            Surname = "Samply",
            NationalIdentificationNumber = "124",
            CoursesInChargeOf = new List<Course>()
        };
        private static readonly Component component = new Component() {
            Id = 1,
            Course = course,
            Name = "Seminari",
            MaximumPoints = 40,
            MinimumPointsToPass = 20
        };
        private static readonly Course course = new Course() {
            Id = 1,
            Name = "Kvantna računala",
            NaturalIdentifier = "KVARC-FER-2016",
            EctsCredits = 5,
            StudentsEnrolled = new List<Student>(),
            LecturersInCharge = new List<Lecturer>(),
            Components = new List<Component>()
        };
        private static readonly Score score = new Score() {
            Id = 1,
            Component = component,
            Student = student,
            Value = 10
        };
        public ComponentTests() {
            score.Component = component;
            score.Student = student;

            course.StudentsEnrolled.Add(student);
            course.LecturersInCharge.Add(lecturer);
            course.Components.Add(component);

            component.Course = course;

            lecturer.CoursesInChargeOf.Add(course);
        }
        [TestMethod]
        public void MVC_ComponentTests_DisplayCourseComponents() {

            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(1)).Returns(lecturer);
            corRepMock.Setup(c => c.GetById(1)).Returns(course);
            IList<Component> components = new List<Component>();
            comRepMock.Setup(c => c.GetAll()).Returns(components);

            var controller = new LecturerController(corRepMock.Object, scrRepMock.Object, usrRepMock.Object, comRepMock.Object);

            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.Session["userId"]).Returns(1);
            controllerContext.SetupGet(p => p.HttpContext.Session["email"]).Returns("sample@svemir.hr");

            controller.ControllerContext = controllerContext.Object;

            var result = controller.Component(1) as ViewResult;
            var viewModel = (IList<ComponentViewModel>)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Count);

        }
        [TestMethod]
        public void MVC_ComponentTests_DisplayComponentStatistics() {

            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(1)).Returns(lecturer);
            corRepMock.Setup(c => c.GetById(1)).Returns(course);
            IList<Component> components = new List<Component>();
            comRepMock.Setup(c => c.GetAll()).Returns(components);
            IList<Score> scores = new List<Score>();
            scrRepMock.Setup(c => c.GetAll()).Returns(scores);

            var controller = new LecturerController(corRepMock.Object, scrRepMock.Object, usrRepMock.Object, comRepMock.Object);

            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.Session["userId"]).Returns(1);
            controllerContext.SetupGet(p => p.HttpContext.Session["email"]).Returns("sample@svemir.hr");

            controller.ControllerContext = controllerContext.Object;

            var result = controller.ComponentStatistics(1) as ViewResult;
            var viewModel = (IList<ComponentStatisticsViewModel>)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Count);
        }
        [TestMethod]
        public void MVC_ComponentTests_CreateComponent() {

            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(1)).Returns(lecturer);
            corRepMock.Setup(c => c.GetById(1)).Returns(course);

            var controller = new LecturerController(corRepMock.Object, scrRepMock.Object, usrRepMock.Object, comRepMock.Object);

            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.Session["userId"]).Returns(1);
            controllerContext.SetupGet(p => p.HttpContext.Session["email"]).Returns("sample@svemir.hr");

            controller.ControllerContext = controllerContext.Object;
            var result = controller.CreateComponent(1) as ViewResult;
            var viewModel = (ComponentViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.CourseId);

        }
        [TestMethod]
        public void MVC_ComponentTests_DeleteComponent() {

            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(1)).Returns(lecturer);
            corRepMock.Setup(c => c.GetById(1)).Returns(course);
            comRepMock.Setup(c => c.GetById(1)).Returns(component);

            var controller = new LecturerController(corRepMock.Object, scrRepMock.Object, usrRepMock.Object, comRepMock.Object);

            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.Session["userId"]).Returns(1);
            controllerContext.SetupGet(p => p.HttpContext.Session["email"]).Returns("sample@svemir.hr");

            controller.ControllerContext = controllerContext.Object;
            var result = controller.DeleteComponent(1, false) as ViewResult;
            var viewModel = (ComponentViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Id);

        }
        [TestMethod]
        public void MVC_ComponentTests_EditComponent() {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(1)).Returns(lecturer);
            corRepMock.Setup(c => c.GetById(1)).Returns(course);
            comRepMock.Setup(c => c.GetById(1)).Returns(component);

            var controller = new LecturerController(corRepMock.Object, scrRepMock.Object, usrRepMock.Object, comRepMock.Object);

            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.Session["userId"]).Returns(1);
            controllerContext.SetupGet(p => p.HttpContext.Session["email"]).Returns("sample@svemir.hr");

            controller.ControllerContext = controllerContext.Object;
            var result = controller.EditComponent(1) as ViewResult;
            var viewModel = (ComponentViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Id);
        }
    }
}
