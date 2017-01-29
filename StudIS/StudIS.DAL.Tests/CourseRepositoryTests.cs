using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.DAL.Repositories;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models;

namespace StudIS.DAL.Tests
{
    [TestClass]
    public class CourseRepositoryTests
    {
        INHibernateService _nhs;
        ICourseRepository _corRep;
        public CourseRepositoryTests()
        {
            _nhs = new NHibernateService2();
            _corRep = new CourseRepository(_nhs);
        }

        [TestMethod]
        public void CourseRepository_Create_Success()
        {
            Course course = new Course()
            {
                Name = "Kvantna računala",
                NaturalIdentifier = "KVARC-FER-2016",
                EctsCredits = 5,
                StudentsEnrolled = null,
                LecturersInCharge = null,
                Components = null
            };
            var created = _corRep.Create(course);

            Assert.IsNotNull(created);
            Assert.IsFalse(created.Id == 0);

        }

        [TestMethod]
        public void CourseRepository_Create_Fail()
        {
            Course course = new Course()
            {
                Name = "Kvantna računala",
                NaturalIdentifier = null,
                EctsCredits = 5,
                StudentsEnrolled = null,
                LecturersInCharge = null,
                Components = null
            };

            try
            {
                var created = _corRep.Create(course);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NHibernate.PropertyValueException);
            }

        }
        [TestMethod]
        public void CourseRepository_GetByNaturalIdentifier_Success()
        {
            Course course = new Course()
            {

                Name = "Kvantna računala",
                NaturalIdentifier = "KVARC-FER-2016",
                EctsCredits = 5,
                StudentsEnrolled = null,
                LecturersInCharge = null,
                Components = null
            };

            _corRep.Create(course);

            var result = _corRep.GetByNaturalIdentifier("KVARC-FER-2016");


            Assert.AreEqual(result.NaturalIdentifier, "KVARC-FER-2016");
            Assert.AreEqual(result.Name, "Kvantna računala");

        }

        [TestMethod]
        public void CourseRepository_GetByNaturalIdentifier_Fail()
        {

            var result = _corRep.GetByNaturalIdentifier("wrong identifier");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CourseRepository_Update_Success()
        {
            Course course = new Course()
            {
                Id = 1,
                Name = "Kvantna računala",
                NaturalIdentifier = "KVARC-FER-2016",
                EctsCredits = 5,
                StudentsEnrolled = null,
                LecturersInCharge = null,
                Components = null
            };
            _corRep.Create(course);

            var created = _corRep.GetById(1);
            created.NaturalIdentifier = "NewNat";

            var updated = _corRep.Update(created);

            Assert.AreEqual(updated.NaturalIdentifier, "NewNat");
        }

    }
}
