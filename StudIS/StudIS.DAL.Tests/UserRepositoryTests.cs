using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudIS.Models.RepositoryInterfaces;
using StudIS.DAL.Repositories;
using StudIS.Models.Users;

namespace StudIS.DAL.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        INHibernateService _nhs;
        IUserRepository _usrRep;
        public UserRepositoryTests()
        {
            _nhs = new NHibernateService2();
            _usrRep = new UserRepository(_nhs);
        }

        [TestMethod]
        public void CreateTest_Success()
        {
            var admin = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = "xxx"
            };
            var created = _usrRep.Create(admin);

            Assert.IsNotNull(created);
            Assert.IsFalse(created.Id == 0);
        }

        [TestMethod]
        public void CreateTest_Fail()
        {
            var admin = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = null
            };
            try
            {
                var created = _usrRep.Create(admin);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NHibernate.PropertyValueException);
            }


        }


        [TestMethod]
        public void DeleteTest_True()
        {
            var admin = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = "xxx"
            };

            var created = _usrRep.Create(admin);

            var wasDeleted = _usrRep.DeleteById(created.Id);


            Assert.IsTrue(wasDeleted);
        }


        [TestMethod]
        public void DeleteTest_False()
        {
            var admin = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = "xxx"
            };

            var created = _usrRep.Create(admin);

            _usrRep.DeleteById(created.Id);
            var wasDeleted = _usrRep.DeleteById(created.Id);


            Assert.IsFalse(wasDeleted);
        }

        [TestMethod]
        public void GetByIdTest_Correct()
        {
            var admin = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = "xxx"
            };

            var created = _usrRep.Create(admin);

            var user = _usrRep.GetById(created.Id);


            Assert.IsNotNull(user);

        }


        [TestMethod]
        public void GetByIdTest_InCorrect()
        {
            _usrRep.DeleteById(10);
            var user = _usrRep.GetById(10);
            Assert.IsNull(user);

        }

        [TestMethod]
        public void GetByEmailTest_Correct()
        {
            var admin = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = "xxx"
            };

            var created = _usrRep.Create(admin);
            var user = _usrRep.GetByEmail(created.Email);
            Assert.IsNotNull(user);

        }

        [TestMethod]
        public void GetByEmailTest_InCorrect()
        {

            var user = _usrRep.GetByEmail("wrongemail");
            Assert.IsNull(user);

        }


        [TestMethod]
        public void UpdateUser_Success()
        {
            var admin = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = "xxx"
            };

            var created = _usrRep.Create(admin);

            created.Name = "UpdatedAdminko";
            var updated = _usrRep.Update(created);

            Assert.IsNotNull(updated);
            Assert.AreEqual(updated.Name, "UpdatedAdminko");

        }



        [TestMethod]
        public void UpdateUser_Fail()
        {
            var admin = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = "xxx"
            };

            var created = _usrRep.Create(admin);

            created.PasswordHash = null;

            try
            {
                var updated = _usrRep.Update(created);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NHibernate.PropertyValueException);
            }
        }

    }
}
