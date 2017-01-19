using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudIS.DAL;
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.DAL.Repositories;
using StudIS.Services;
using StudIS.Desktop.Controllers;

namespace StudIS.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            User MockUser = new Student()
            {
                
                Email = "tibor@svemir.hr",
                PasswordHash = "123abc".GetHashCode().ToString(),
                Name = "Tibor",
                Surname = "Žukina",
                NationalIdentificationNumber = "12345",
                StudentIdentificationNumber = "0036412345",
                CoursesEnrolledIn = null
            };

            var nhService = new NHibernateService();
            var session = nhService.OpenSession();

            var userRepository = new UserRepository(session);
            var courseRepository = new MockCourseRepository();
            var loginService = new LoginService(userRepository);

            var mainFormController = new MainFormController(userRepository, courseRepository);
            var loginFormController = new LoginFormController(loginService, mainFormController);
            var courseFormController = new CourseFormController(courseRepository, userRepository);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(mainFormController, loginFormController, courseFormController));
        }
    }
}
