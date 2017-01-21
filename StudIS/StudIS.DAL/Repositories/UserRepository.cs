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
using NHibernate.Criterion;
using StudIS.DAL;
using StudIS.Models.Users;

namespace StudIS.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ISession _session;

        public UserRepository(INHibernateService nhs)
        {
            _session = nhs.OpenSession();
        }

        public IList<User> GetAll()
        {
            return _session.QueryOver<User>().List();
        }

        public User Create(User user)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(user);
                transaction.Commit();
                return user;
            }
        }

        public bool DeleteById(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var user = GetById(id);

                if (user == null)
                    return false;

                _session.Delete(user);
                transaction.Commit();
                return true;
            }
        }

        public bool DeleteByNationalIdentificationNumber(string nationalIdentificationNumber)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var user = GetByNationalIdentificationNumbe(nationalIdentificationNumber);

                if (user == null)
                    return false;

                _session.Delete(user);
                transaction.Commit();
                return true;
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
            return _session.CreateCriteria<User>()
                .Add(Expression.Like("Email", email))
                .UniqueResult<User>();
        }

        public User GetById(int id)
        {
             return _session.Get<User>(id);
        }

        public User GetByNationalIdentificationNumbe(string nationalIdentificationNumbe)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(user);
                transaction.Commit();
                return user;
            }
        }

        ~UserRepository()
        {
            _session.Close();
            _session.Dispose();
            _session = null;
        }
    }
}
