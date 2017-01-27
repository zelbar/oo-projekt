using System.Collections.Generic;
using StudIS.Models;
using StudIS.Services;

namespace StudIS.Desktop.Controllers
{
    public class MainFormController
    {
        private readonly UserServices _userServices;
        private readonly CourseServices _courseServices;

        public MainFormController(UserServices userServices, CourseServices courseServices)
        {
            _userServices = userServices;
            _courseServices = courseServices;
        }

        public IList<Course> GetAllCourses()
        {
            return _courseServices.GetAllCourses();
        }
    }
}
