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

namespace StudIS.Web.Mvc.Tests
{
    [TestClass]
    public class StudentTests
    {
        private static readonly Student student = new Student()
        {
            Id = 1,
            Email = "example@svemir.hr",
            PasswordHash = "hash",
            Name = "Example",
            Surname = "Examply",
            NationalIdentificationNumber = "124",
            StudentIdentificationNumber = "343"
        };
        private static readonly Lecturer lecturer = new Lecturer()
        {
            Id = 2,
            Email = "sample@svemir.hr",
            PasswordHash = "hash",
            Name = "Sample",
            Surname = "Samply",
            NationalIdentificationNumber = "124"
        };
        private static readonly Component component = new Component()
        {
            Id = 534,
            Course = course,
            Name = "Seminari",
            MaximumPoints = 40,
            MinimumPointsToPass = 20

        };
        private static readonly Course course = new Course()
        {
            Id=1,
            Name = "Kvantna računala",
            NaturalIdentifier = "KVARC-FER-2016",
            EctsCredits = 5,
            StudentsEnrolled = new List<Student>() { student },
            LecturersInCharge = new List<Lecturer>() { lecturer },
            Components = new List<Component>() { component }
        };
        private static readonly Score score = new Score()
        {
            Id = 1,
            Component = component,
            Student = student,
            Value = 10
        };

      public StudentTests()
        {
 
        }

        [TestMethod]
        public void MVC_StudentTests_DisplayScoreInfo()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            corRepMock.Setup(c => c.GetById(1)).Returns(course);
            usrRepMock.Setup(c => c.GetById(1)).Returns(student);
            scrRepMock.Setup(c => c.GetByStudentIdAndComponentId(It.IsAny<Student>(), It.IsAny<Component>())).Returns(score);


            var controller = new StudentController(corRepMock.Object, scrRepMock.Object, usrRepMock.Object, comRepMock.Object);

            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.Session["userId"]).Returns(1);
            controllerContext.SetupGet(p => p.HttpContext.Session["email"]).Returns("example@svemir.hr");

            controller.ControllerContext = controllerContext.Object;

            var result=controller.ScoreInfo(1) as ViewResult;
            var viewModel = (ScoredCourseViewModel)result.ViewData.Model;

            Assert.AreEqual("Kvantna računala", viewModel.Name);


        }
        [TestMethod]
        public void MVC_StudentTests_DisplayPersonalData()
        {
            Mock<IUserRepository> usrRepMock = new Mock<IUserRepository>();
            Mock<ICourseRepository> corRepMock = new Mock<ICourseRepository>();
            Mock<IScoreRepository> scrRepMock = new Mock<IScoreRepository>();
            Mock<IComponentRepository> comRepMock = new Mock<IComponentRepository>();

            usrRepMock.Setup(c => c.GetById(1)).Returns(student);


            var controller = new StudentController(corRepMock.Object, scrRepMock.Object, usrRepMock.Object, comRepMock.Object);

            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.Session["userId"]).Returns(1);
            controllerContext.SetupGet(p => p.HttpContext.Session["email"]).Returns("example@svemir.hr");

            controller.ControllerContext = controllerContext.Object;

            var result = controller.PersonalData() as ViewResult;
            var viewModel = (StudentViewModel)result.ViewData.Model;


            Assert.AreEqual(student.Email, viewModel.Email);
        }
    }
}

