using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
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
        private IUserRepository _userRepository;

        public ScoreServices(IScoreRepository scoreRepository, ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _scoreRepository = scoreRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;

        }

        public IList<Score> GetScorebyStudentAndCourse(int studentId, int courseId)
        {
            

            var student = _userRepository.GetById(studentId);
            if (student==null || !UserServices.IsUserStudent(student))
                return new List<Score>();
            

            
            var course = _courseRepository.GetById(courseId);
            var componentList = course.Components;

            if (componentList == null)
                return new List<Score>();

            var scoreList = new List<Score>();

            foreach (var component in componentList)
            {
                var score = _scoreRepository.GetByStudentIdAndComponentId((Student)student, component);
                if(score==null)
                {
                    var defaultScore = new Score()
                    {
                        Student = (Student)student,
                        Component = component,
                        Value = 0,


                    };
                   score= _scoreRepository.CreateOrUpdate(defaultScore);
                }
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
