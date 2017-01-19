using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudIS.DAL;
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.DAL.Repositories;

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

            var service = new NHibernateService();
            var rep = new UserRepository(service);
            rep.Create(MockUser);

            var session = service.OpenSession();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
