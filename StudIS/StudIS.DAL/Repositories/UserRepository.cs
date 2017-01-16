using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using FluentNHibernate;
using FluentNHibernate.Data;
using NHibernate;
using StudIS.Models.RepositoryInterfaces;

namespace StudIS.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            _nhs = new NhibernateService();
        }

        private readonly NhibernateService _nhs;

        public IList<User> GetAll()
        {
            using (var session = _nhs.OpenSession())
            {
                return session.QueryOver<User>().List();
            }
        }

        public User Create(User user)
        {
            using (var session = _nhs.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                    return user;
                }
            }
        }

        public bool DeleteById(int id)
        {
            using (var session = _nhs.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = GetById(id);

                    if (user == null)
                        return false;

                    session.Delete(user);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public bool DeleteByNationalIdentificationNumber(string nationalIdentificationNumber)
        {
            using (var session = _nhs.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = GetByNationalIdentificationNumbe(nationalIdentificationNumber);

                    if (user == null)
                        return false;

                    session.Delete(user);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public IList<User> GetByCourse(Course course)
        {
            throw new NotImplementedException();

            // How to query admins in this manner?
            //using (var session = _nhs.OpenSession())
            //{
            //    var rv = session.QueryOver<User>().Where(x => x.)
            //}
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            using (var session = _nhs.OpenSession())
            {
                return session.Get<User>(id);
            }
        }

        public User GetByNationalIdentificationNumbe(string nationalIdentificationNumbe)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            using (var session = _nhs.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                    return user;
                }
            }
        }
    }
}
