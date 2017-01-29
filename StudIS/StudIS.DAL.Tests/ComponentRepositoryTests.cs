using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Models;
using StudIS.DAL.Repositories;
using StudIS.Models.RepositoryInterfaces;

namespace StudIS.DAL.Tests
{
    [TestClass]
    public class ComponentRepositoryTests
    {
        INHibernateService _nhs;
        ICourseRepository _corRep;
        IComponentRepository _comRep;

        public ComponentRepositoryTests()
        {
            _nhs = new NHibernateService2();
            _corRep = new CourseRepository(_nhs);
            _comRep = new ComponentRepository(_nhs);
        }

        [TestMethod]
        public void ComponentRepository_Create_Success()
        {
            Course course = new Course()
            {

                Name = "Kvantna računala",
                NaturalIdentifier = "KVARC-FER-2016",
                EctsCredits = 5,
                Components = null,
                LecturersInCharge = null,
                StudentsEnrolled = null


            };

            var savedCourse = _corRep.Create(course);

            Component component = new Component()
            {

                Course = savedCourse,
                Name = "Seminari",
                MaximumPoints = 40,
                MinimumPointsToPass = 20

            };

            var created = _comRep.Create(component);

            Assert.IsNotNull(created);
            Assert.AreEqual(created.Name, "Seminari");

        }

        [TestMethod]
        public void ComponentRepository_Create_Fail()
        {
            Course course = new Course()
            {

                Name = "Kvantna računala",
                NaturalIdentifier = "KVARC-FER-2016",
                EctsCredits = 5,
                Components = null,
                LecturersInCharge = null,
                StudentsEnrolled = null


            };


            Component component = new Component()
            {

                Course = course,
                Name = "Seminari",
                MaximumPoints = 40,
                MinimumPointsToPass = 20

            };

            try
            {
                var created = _comRep.Create(component);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NHibernate.TransientObjectException);
            }
        }



        [TestMethod]
        public void ComponentRepository_Update_Success()
        {
            Course course = new Course()
            {

                Name = "Kvantna računala",
                NaturalIdentifier = "KVARC-FER-2016",
                EctsCredits = 5,
                Components = null,
                LecturersInCharge = null,
                StudentsEnrolled = null


            };

            var savedCourse = _corRep.Create(course);

            Component component = new Component()
            {

                Course = savedCourse,
                Name = "Seminari",
                MaximumPoints = 40,
                MinimumPointsToPass = 20

            };

            var created = _comRep.Create(component);
            created.Name = "NewName";

            var updated = _comRep.Update(created);

            Assert.IsNotNull(updated);
            Assert.AreEqual(updated.Name, "NewName");

        }
    }
}
