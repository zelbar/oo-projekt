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
        /// <summary>
        /// Show the list of available courses
        /// </summary>
        /// <returns></returns>
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
            var user = _userRepository.GetById(lecturerId);

            if (user == null || !UserServices.isUserLecturer(user))
                return RedirectToAction("Index", "Home");

            return View(new LecturerViewModel((Lecturer)user));

        }

        public ActionResult Component(int id) {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            var course = _courseRepository.GetById(id);
            ViewBag.Title = course.Name;
            ViewBag.Email = Session["email"];

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

            var component = _componentRepository.GetById(id);
            ViewBag.Title = component.Name + " " + component.Course.Name;
            ViewBag.Email = Session["email"];

            return View(new ComponentViewModel(component));
        }

        [HttpPost]
        public ActionResult EditComponent(ComponentViewModel comp) {
            var course = _courseRepository.GetById(comp.CourseId);
            Component newComponent = new Component() {
                Id = comp.Id,
                Name = comp.Name,
                Course = course,
                MaximumPoints = comp.MaximumPoints,
                MinimumPointsToPass = comp.MinimumPointsToPass
            };

            var component = _componentRepository.Update(newComponent);

            return RedirectToAction("Index", "Lecturer");
        }

        public ActionResult DeleteComponent(int id) {

            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            var component = _componentRepository.GetById(id);
            ViewBag.Title = component.Name + " " + component.Course.Name;
            ViewBag.Email = Session["email"];

            return View(new ComponentViewModel(component));
        }

        [HttpPost, ActionName("DeleteComponent")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComponentConfirmed(int id) {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");
            var component = _componentRepository.DeleteById(id);
            return RedirectToAction("Index", "Lecturer");
        }

        public ActionResult CreateComponent(int id) {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Title = "Nova komponenta";
            ViewBag.Email = Session["email"];

            var course = _courseRepository.GetById(id);
            Component newComponent = new Component() {
                Course = course
            };
            return View(new ComponentViewModel(newComponent));
        }

        [HttpPost]
        public ActionResult CreateComponent(ComponentViewModel comp) {
            var course = _courseRepository.GetById(comp.CourseId);

            Component newComponent = new Component() {
                Name = comp.Name,
                Course = course,
                MaximumPoints = comp.MaximumPoints,
                MinimumPointsToPass = comp.MinimumPointsToPass
            };

            var component = _componentRepository.Create(newComponent);

            return RedirectToAction("Index", "Lecturer");
        }
    }
}