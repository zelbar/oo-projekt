using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Services
{
    public class ScoreServices
    {
        private IScoreRepository _scoreRepository;
        private ICourseRepository _courseRepository;

        public ScoreServices(IScoreRepository scoreRepository, ICourseRepository courseRepository)
        {
            _scoreRepository = scoreRepository;
            _courseRepository = courseRepository;

        }

        public IList<Score> GetScorebyStudentAndCourse(int studentId, int courseId)
        {
            //var scoreList = _scoreRepository.GetByStudentAndCourse(studentId, courseId);

            var course = _courseRepository.GetById(courseId);
            var componentList = course.Components;
            var scoreList = new List<Score>();

            foreach(var component in componentList)
            {
                var score=_scoreRepository.GetByStudentIdAndComponentId(studentId, component.Id);
                scoreList.Add(score);
            }


            return scoreList;
        }

        public bool SaveScore(Score score)
        {
            var newScore = _scoreRepository.CreateOrUpdate(score);
            if (newScore != null)
                return true;
            else
                return false;
        }

    }
}
