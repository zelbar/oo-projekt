using System;
using System.Windows.Forms;
using StudIS.DAL;
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
            var userServices = new UserServices(userRepository);
            var courseServices = new CourseServices(courseRepository, userRepository, componentRepository);

            var mainFormController = new MainFormController(userServices, courseServices);
            var loginFormController = new LoginFormController(mainFormController, loginService);
            var courseFormController = new CourseFormController(courseServices, userServices);
            var userFormController = new UserFormController(userServices, courseServices);

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
