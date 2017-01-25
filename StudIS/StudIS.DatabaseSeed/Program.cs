using System.Collections.Generic;
using StudIS.DAL;
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.DAL.Repositories;
using StudIS.Services;

namespace StudIS.DatabaseSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            var nhService = new NHibernateService();

            var userRepository = new UserRepository(nhService);
            var courseRepository = new CourseRepository(nhService);
            var componentRepository = new ComponentRepository(nhService);
            var scoreRepository = new ScoreRepository(nhService);

            #region Seeding

            var lecturer = new Lecturer()
            {
                Email = "tibor@svemir.hr",
                PasswordHash = EncryptionService.EncryptSHA1("pare"),
                Name = "Tibor",
                Surname = "Žukina",
                NationalIdentificationNumber = "12345"
            };
            var administrator = new Administrator()
            {
                Email = "zeljko@uni.hr",
                PasswordHash = EncryptionService.EncryptSHA1("123abc"),
                Name = "Željko",
                Surname = "Baranek",
                NationalIdentificationNumber = "123456"
            };
            var student = new Student()
            {
                Name = "Zlatko",
                Surname = "Hrastić",
                Email = "zlatko.hrastic@fer.hr",
                NationalIdentificationNumber = "343999999",
                StudentIdentificationNumber = "0036476522",
                CoursesEnrolledIn = new List<Course>(),
                PasswordHash = EncryptionService.EncryptSHA1("jabuka")

            };

            Component medjuispit = new Component()
            {
                MaximumPoints = 30,
                MinimumPointsToPass = 0,
                Name = "Međuispit"
            };
            Component zavrsni = new Component()
            {
                MaximumPoints = 40,
                MinimumPointsToPass = 14,
                Name = "Završni ispit"
            };

            var componentList = new List<Component>();
            componentList.Add(medjuispit);
            componentList.Add(zavrsni);

            Course MockCourse = new Course()
            {
                Id = 1,
                Name = "Objektno oblikovanje",
                NaturalIdentifier = "ObjOblFER2016OO",
                EctsCredits = 5,
                Components = componentList,
                LecturersInCharge = new List<Lecturer>(),
                StudentsEnrolled = new List<Student>()
            };
            Course MockCourse2 = new Course()
            {
                Id = 2,
                Name = "Napredni algoritmi i strukture podataka",
                NaturalIdentifier = "NASP-FER-2016OO",
                EctsCredits = 5,
                Components = null,
                LecturersInCharge = new List<Lecturer>(),
                StudentsEnrolled = new List<Student>()
            };

            var score = new Score()
            {
                Component = medjuispit,
                Student = student,
                Value = 20
            };

            var service = new UserServices(userRepository);
            service.createUser(student);
            service.createUser(lecturer);
            service.createUser(administrator);

            MockCourse.StudentsEnrolled.Add(student);
            MockCourse.LecturersInCharge.Add(lecturer);

            courseRepository.Create(MockCourse);
            courseRepository.Create(MockCourse2);

            scoreRepository.CreateOrUpdate(score);

            #endregion

            System.Console.WriteLine("Seed successfully completed.");
            System.Console.Read();
        }
    }
}
