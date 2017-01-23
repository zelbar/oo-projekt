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
        /// <param name="id">id of the student</param>
        /// <returns></returns>
        public List<SimpleCourseModel> GetCoursesByStudentId(int id)
        {
            var courses=_corRep.GetByUserId(id);
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

        public IList<Score> GetScoreData(int studentId,int courseId)
        {
            var scoreServices = new ScoreServices(_scrRep,_corRep);
            var scoreList=scoreServices.GetScorebyStudentAndCourse(studentId, courseId);
            return scoreList;
        }

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
