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
            var student = new Administrator()
            {
                Email="admin@admin.ad",
                Name="Adminko",
                Surname="Adminic",
                NationalIdentificationNumber="12345",
                PasswordHash="xxx"
            };
            var created=_usrRep.Create(student);

            Assert.IsNotNull(created);
            Assert.IsFalse(created.Id == 0);
        }

        [TestMethod]
        public void CreateTest_Fail()
        {
            var student = new Administrator()
            {
                Email = "admin@admin.ad",
                Name = "Adminko",
                Surname = "Adminic",
                NationalIdentificationNumber = "12345",
                PasswordHash = null
            };
            var created = _usrRep.Create(student);

            Assert.IsNull(created);
        }

    }
}
