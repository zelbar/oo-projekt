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
    public class MainFormController
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;

        public MainFormController(IUserRepository userRepository, ICourseRepository courseRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }
    }
}
