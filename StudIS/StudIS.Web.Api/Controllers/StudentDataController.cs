using StudIS.DAL;
using StudIS.DAL.Repositories;
using StudIS.Models;
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
        private INHibernateService _nhService;

        public StudentDataController(INHibernateService nhService)
        {
            _nhService = nhService;
        }

        public List<SimpleCourseModel> getCoursesByStudentId(int id)
        {
            var repository = new MockCourseRepository();
            var courses=repository.GetByUserId(id);
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
    }
}
