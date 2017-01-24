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
            var courseRepository = new MockCourseRepository();
            var loginService = new LoginService(userRepository);

            //#region isprobavanje

            //Student MockUser = new Student()
            //{
            //    Id = 1,
            //    Email = "tibor@svemir.hr",
            //    PasswordHash = "123abc".GetHashCode().ToString(),
            //    Name = "Tibor",
            //    Surname = "Žukina",
            //    NationalIdentificationNumber = "12345",
            //    StudentIdentificationNumber = "0036412345",
            //    CoursesEnrolledIn = null
            //};
            //Student MockUser2 = new Student()
            //{

            //    Email = "zeljko@svemir.hr",
            //    PasswordHash = "123abc".GetHashCode().ToString(),
            //    Name = "Zeljko",
            //    Surname = "Baranek",
            //    NationalIdentificationNumber = "123456",
            //    StudentIdentificationNumber = "00364123456",
            //    CoursesEnrolledIn = null
            //};


            //Course MockCourse = new Course()
            //{
            //    Id = 1,
            //    Name = "Objektno oblikovanje",
            //    NaturalIdentifier = "ObjOblFER2016OO",
            //    EctsCredits = 5,
            //    Components = null,
            //    LecturersInCharge = null,
            //    StudentsEnrolled = null
            //};
            //Course MockCourse2 = new Course()
            //{
            //    Id = 2,
            //    Name = "Napredni algoritmi i strukture podataka",
            //    NaturalIdentifier = "NASP-FER-2016OO",
            //    EctsCredits = 5,
            //    Components = null,
            //    LecturersInCharge = null,
            //    StudentsEnrolled = null
            //};
            //Student ja = new Student()
            //{
            //    Name = "Zlatko",
            //    Surname = "Hrastić",
            //    CoursesEnrolledIn = null,
            //    Email = "zlatko.hrastic@fer.hr",
            //    NationalIdentificationNumber = "343999999",
            //    StudentIdentificationNumber = "0036476522",
            //    PasswordHash = EncryptionService.EncryptSHA1("jabuka")

            //};
            //var service = new UserServices(userRepository);
            //service.createUser(ja);

            //// userRepository.Create(MockUser);
            ////userRepository.Create(MockUser2);

            ////var studentList = new List<Student>();
            ////studentList.Add((Student)userRepository.GetById(1));
            ////studentList.Add((Student)userRepository.GetById(2));

            ////MockCourse.StudentsEnrolled = studentList;
            ////userRepository.GetByCourse(MockCourse);

            //////courseRep.Create(MockCourse);
            //////courseRep.Create(MockCourse2);
            //#endregion


            var mainFormController = new MainFormController(userRepository, courseRepository);
            var loginFormController = new LoginFormController(loginService, mainFormController);
            var courseFormController = new CourseFormController(courseRepository, userRepository);
            var userFormController = new UserFormController(userRepository, courseRepository);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm(
                mainFormController, 
                loginFormController, 
                courseFormController, 
                userFormController);
            Application.Run(mainForm);
        }
    }
}
