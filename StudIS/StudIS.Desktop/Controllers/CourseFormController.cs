using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.DAL;
using StudIS.DAL.Repositories;

namespace StudIS.Desktop.Controllers
{
    public class CourseFormController
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public CourseFormController(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }


    }
}
