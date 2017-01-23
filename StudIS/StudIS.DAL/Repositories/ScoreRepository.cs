using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using NHibernate;
using NHibernate.Criterion;

namespace StudIS.DAL.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private ISession _session;

        public ScoreRepository(INHibernateService nhs)
        {
            _session = nhs.OpenSession();
        }
        //public IList<Score> GetByStudentAndCourse(int studentId, int courseId)
        //{
        //    var score = _session.QueryOver<Score>().Where(s=>s.Student.Id==studentId)
        //                     .Right.JoinQueryOver<Component>(s => s.Component)
        //                     .Where(c=>c.CourseId==courseId)
        //                     .List<Score>();
        //    return score;
        //}

        public Score Create(Score score)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(score);
                transaction.Commit();
                return score;
            }
        }

        public Score Update(Score score)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(score);
                transaction.Commit();
                return score;
            }
        }

        public Score CreateOrUpdate(Score score)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(score);
                transaction.Commit();
                return score;
            }
        }

        public Score GetById(int id)
        {
            return _session.Get<Score>(id);
        }

        public Score GetByStudentIdAndComponentId(int studentId, int componentId)
        {
            // return _session.QueryOver<Score>().Where(c=>c.Student.Id==studentId).Where(c=>c.Component.Id==componentId).SingleOrDefault();
            var varijabla = _session.QueryOver<Score>().Where(c => c.Student.Id == studentId).List<Score>();
            return null;
        }
    }
}
