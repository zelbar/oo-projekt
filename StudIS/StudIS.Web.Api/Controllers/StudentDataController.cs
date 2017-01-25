using StudIS.DAL;
using StudIS.DAL.Repositories;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models;
using StudIS.Services;
using StudIS.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudIS.Web.Api.Controllers
{
    public class StudentDataController : ApiController
    {
        private IUserRepository _usrRep;
        private ICourseRepository _corRep;
        private IScoreRepository _scrRep;

        public StudentDataController(IUserRepository usrRep,ICourseRepository corRep,IScoreRepository scrRep)
        {
            _usrRep = usrRep;
            _corRep = corRep;
            _scrRep = scrRep;

        }

        /// <summary>
        /// Returns simpleCourse model for student with given id, returns null otherwise
        /// </summary>
        /// <param name="studentId">id of the student</param>
        /// <returns></returns>
        [Route("api/StudentData/GetCoursesByStudentId/{studentId}")]
        public List<SimpleCourseModel> GetCoursesByStudentId(int studentId)
        {
            var courseServices = new CourseServices(_corRep);
            var courses = courseServices.GetCoursesByUserId(studentId);          
            if (courses == null)
                return null;
            else
            {
                var simpleCourseList = new List<SimpleCourseModel>();
                foreach(var course in courses)
                {
                    simpleCourseList.Add(new SimpleCourseModel(course));
                }

                return simpleCourseList;
            }


        }
        [Route("api/StudentData/GetScoreData/{studentId}/{courseId}")]
        public ScoredCourse GetScoreData(int studentId,int courseId)
        {
            
            var scoreServcies = new ScoreServices(_scrRep, _corRep, _usrRep);
            var courseServices = new CourseServices(_corRep);

            var course = courseServices.GetCourseById(courseId);

            var scores = scoreServcies.GetScorebyStudentAndCourse(studentId, courseId);
            var scoresViewModel = new List<SimpleScore>();
            foreach (var score in scores)
            {
                scoresViewModel.Add(new SimpleScore(score));
            }
            scoresViewModel.Sort((m1, m2) => m1.ComponentName.CompareTo(m2.ComponentName));



            var scoredCourse = new ScoredCourse()
            {
                Name = course.Name,
                ScoreList = scoresViewModel

            };

            return scoredCourse;
        }
        [Route("api/StudentData/GetStudentData/{id}")]
        public SimpleStudentModel GetStudentData(int id)
        {
            var studentServices = new StudentServices(_usrRep);
            var student = studentServices.getStudentdata(id);
            if (student != null)
                return new SimpleStudentModel(student);
            else return null;
        }
    }
}
