﻿using StudIS.Models.RepositoryInterfaces;
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

        public LecturerController(ICourseRepository courseRepository, IScoreRepository scoreRepository, IUserRepository userRepository,IComponentRepository componentRepository) {
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
            List<StudentCourseViewModel> courseList = new List<StudentCourseViewModel>();

            var courseServices = new CourseServices(_courseRepository,_userRepository,_componentRepository);
            var courses = courseServices.GetCoursesByUserId(userId);

            if (courses != null) {
                foreach (var course in courses) {
                    courseList.Add(new StudentCourseViewModel(course));
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
    }
}