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
            var nhService = new NHibernateService();
            
            var userRepository = new UserRepository(nhService);
            var courseRepository = new CourseRepository(nhService);
            var componentRepository = new ComponentRepository(nhService);
            var scoreRepository = new ScoreRepository(nhService);

            var loginService = new LoginService(userRepository);

            var mainFormController = new MainFormController(userRepository, courseRepository);
            var loginFormController = new LoginFormController(mainFormController, loginService);
            var courseFormController = new CourseFormController(courseRepository, userRepository);
            var userFormController = new UserFormController(userRepository, courseRepository);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new LoginForm(loginFormController);

            var mainForm = new MainForm(
                mainFormController, 
                loginFormController, 
                courseFormController, 
                userFormController);

            Application.Run(loginForm);
            var loginResult = loginForm.LoginResult;

            if (loginResult)
            {
                Application.Run(mainForm);
            }
        }
    }
}
