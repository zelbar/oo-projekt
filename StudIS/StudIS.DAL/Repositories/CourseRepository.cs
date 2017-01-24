using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using NHibernate;
using NHibernate.Criterion;
using StudIS.Models.Users;

namespace StudIS.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private ISession _session;

        public CourseRepository(INHibernateService nhs)
        {
            _session = nhs.OpenSession();
        }

        public Course Create(Course course)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(course);
                transaction.Commit();
                return course;
            }
        }

        public bool DeleteById(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var course = GetById(id);

                if (course == null)
                    return false;

                _session.Delete(course);
                transaction.Commit();
                return true;
            }
        }

        public bool DeleteByNaturalIdentifier(string naturalIdentifier)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var user = GetByNaturalIdentifier(naturalIdentifier);

                if (user == null)
                    return false;

                _session.Delete(user);
                transaction.Commit();
                return true;
            }
        }

        public IList<Course> GetAll()
        {
            return _session.QueryOver<Course>().List();
        }

        public Course GetById(int id)
        {
            return _session.Get<Course>(id);
        }

        public Course GetByNaturalIdentifier(string naturalIdentifier)
        {
            return _session.CreateCriteria<Course>()
                .Add(Expression.Like("NaturalIdentifier", naturalIdentifier))
                .UniqueResult<Course>();
        }

        public IList<Course> GetByUserId(int userId)
        {

            var users = _session.QueryOver<Course>()
                             .Right.JoinQueryOver<User>(c => c.StudentsEnrolled)
                             .Where(u => u.Id == userId)
                             .List();
            if (users[0] == null)
                return null;


            return users;
        }

        public Course Update(Course course)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(course);
                transaction.Commit();
                return course;
            }
        }
    }
}
