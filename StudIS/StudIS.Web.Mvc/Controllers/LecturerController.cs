using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
using StudIS.Services;
using StudIS.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudIS.Web.Mvc.Controllers {
    public class LecturerController : Controller {

        private ICourseRepository _courseRepository;
        private IScoreRepository _scoreRepository;
        private IUserRepository _userRepository;
        private IComponentRepository _componentRepository;

        public LecturerController(ICourseRepository courseRepository, IScoreRepository scoreRepository, IUserRepository userRepository, IComponentRepository componentRepository) {
            _courseRepository = courseRepository;
            _scoreRepository = scoreRepository;
            _userRepository = userRepository;
            _componentRepository = componentRepository;

        }

        public ActionResult Index() {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Email = Session["email"];
            ViewBag.Title = "Predmeti";

            int userId = (int)Session["userId"];
            List<LecturerCourseViewModel> courseList = new List<LecturerCourseViewModel>();

            var courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);
            var courses = courseServices.GetCoursesByLecturerId(userId);

            if (courses != null) {
                foreach (var course in courses) {
                    courseList.Add(new LecturerCourseViewModel(course));
                }
            }
            return View(courseList);
        }
        public ActionResult PersonalData() {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Email = Session["email"];
            ViewBag.Title = "Osobni podaci";
            var lecturerId = (int)Session["userId"];

            var userServices = new UserServices(_userRepository);
            var user = userServices.GetUserById(lecturerId);

            if (user == null || !UserServices.IsUserLecturer(user))
                return RedirectToAction("Index", "Home");

            return View(new LecturerViewModel((Lecturer)user));

        }

        public ActionResult Component(int id) {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            var courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);
            var course = courseServices.GetCourseById(id);

            ViewBag.Title = course.Name;
            ViewBag.Email = Session["email"];
            ViewBag.Id = course.Id;

            if (course == null)
                return RedirectToAction("Index", "Home");

            List<ComponentViewModel> components = new List<ComponentViewModel>();
            foreach (var component in course.Components) {
                components.Add(new ComponentViewModel(component));
            }
            return View(components);

        }

        public ActionResult EditComponent(int id) {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            var componentServices = new ComponentServices(_componentRepository, _courseRepository);
            var component = componentServices.GetById(id);

            ViewBag.Title = component.Name + " " + component.Course.Name;
            ViewBag.Email = Session["email"];

            return View(new ComponentViewModel(component));
        }

        [HttpPost]
        public ActionResult EditComponent(ComponentViewModel comp) {

            var componentServices = new ComponentServices(_componentRepository, _courseRepository);
            var component = componentServices.UpdateComponent(comp.Name, comp.Id, comp.MinimumPointsToPass, comp.MaximumPoints);

            return RedirectToAction("Component", "Lecturer", new { id = comp.CourseId });
        }

        public ActionResult DeleteComponent(int id) {

            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            var componentServices = new ComponentServices(_componentRepository, _courseRepository);
            var component = componentServices.GetById(id);

            ViewBag.Title = component.Name + " " + component.Course.Name;
            ViewBag.Email = Session["email"];

            return View(new ComponentViewModel(component));
        }

        [HttpPost, ActionName("DeleteComponent")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComponentConfirmed(int id) {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            var componentServices = new ComponentServices(_componentRepository, _courseRepository);
            componentServices.DeleteComponent(id);

            return RedirectToAction("Index", "Lecturer");
        }

        public ActionResult CreateComponent(int id) {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Title = "Nova komponenta";
            ViewBag.Email = Session["email"];

            var courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);
            var course = courseServices.GetCourseById(id);

            Component newComponent = new Component() {
                Course = course
            };
            return View(new ComponentViewModel(newComponent));
        }

        [HttpPost]
        public ActionResult CreateComponent(ComponentViewModel comp) {
            var courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);
            var course = courseServices.GetCourseById(comp.Id);

            var componentServices = new ComponentServices(_componentRepository, _courseRepository);
            var component = componentServices.CreateComponent(comp.Name, comp.CourseId, comp.MinimumPointsToPass, comp.MaximumPoints);

            return RedirectToAction("Component", "Lecturer", new { id = comp.CourseId });
        }

        public ActionResult StudentsEnrolled(int id) {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Email = Session["email"];

            var courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);
            var course = courseServices.GetCourseById(id);

            ViewBag.Title = course.Name;

            var studentServices = new StudentServices(_userRepository);
            var scoreServices = new ScoreServices(_scoreRepository, _courseRepository, _userRepository);
            IList<Student> enrolledStudents = studentServices.GetStudentsByCourse(course);
            IList<StudentEnrollementViewModel> enroll = new List<StudentEnrollementViewModel>();

            foreach (Student s in enrolledStudents) {
                IList<Score> score = scoreServices.GetScorebyStudentAndCourse(s.Id, course.Id);
                enroll.Add(new StudentEnrollementViewModel(score));
            }
            return View(enroll);
        }
        [HttpPost]
        public ActionResult StudentsEnrolled(IEnumerable<StudentEnrollementViewModel> list) {

            var scoreServices = new ScoreServices(_scoreRepository, _courseRepository, _userRepository);
            var componentServices = new ComponentServices(_componentRepository, _courseRepository);
            var userServices = new UserServices(_userRepository);

            foreach (var s in list) {
                foreach (var scor in s.scores) {
                    Score ss = new Score() {
                        Id = scor.Id,
                        Value = scor.Value,
                        Component = componentServices.GetById(scor.Component.Id),
                        Student = (Student)userServices.GetUserById(scor.Student.Id)
                    };
                    scoreServices.SaveScore(ss);
                }
            }
            return RedirectToAction("Index", "Lecturer");
        }
    }
}