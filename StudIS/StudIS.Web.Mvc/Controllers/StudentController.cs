﻿using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
using StudIS.Services;
using StudIS.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudIS.Web.Mvc.Controllers
{
    public class StudentController : Controller
    {

        private ICourseRepository _courseRepository;
        private IScoreRepository _scoreRepository;
        private IUserRepository _userRepository;
        IComponentRepository _componentRepository;

        public StudentController(ICourseRepository courseRepository, IScoreRepository scoreRepository, IUserRepository userRepository, IComponentRepository componentRepository)
        {
            _courseRepository = courseRepository;
            _scoreRepository = scoreRepository;
            _userRepository = userRepository;
            _componentRepository = componentRepository;

        }

        // GET: Student
        /// <summary>
        /// Show the list of available courses
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Email = Session["email"];
            ViewBag.Title = "Predmeti";

            int userId = (int)Session["userId"];
            List<StudentCourseViewModel> courseList = new List<StudentCourseViewModel>();

            var courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);
            var courses = courseServices.GetCoursesByUserId(userId);

            if (courses != null)
            {
                foreach (var course in courses)
                {
                    courseList.Add(new StudentCourseViewModel(course));
                }
            }

            return View(courseList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns></returns>
        public ActionResult ScoreInfo(int id)
        {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Email = Session["email"];
            ViewBag.Title = "Bodovi";
            var studentId = (int)Session["userId"];
            var scoreServcies = new ScoreServices(_scoreRepository, _courseRepository, _userRepository);
            var courseServices = new CourseServices(_courseRepository, _userRepository, _componentRepository);

            var course = courseServices.GetCourseById(id);

            var scores = scoreServcies.GetScorebyStudentAndCourse(studentId, id);
            var scoresViewModel = new List<ScoreViewModel>();

            float cumScore = 0;
            foreach (var score in scores)
            {
                scoresViewModel.Add(new ScoreViewModel(score));
                cumScore += score.Value;
            }
            scoresViewModel.Sort((m1, m2) => m1.ComponentName.CompareTo(m2.ComponentName));



            var scoredCourse = new ScoredCourseViewModel()
            {
                Name = course.Name,
                scoreList = scoresViewModel,
                cumulativeScore=cumScore

            };
            return View(scoredCourse);
        }

        public ActionResult PersonalData()
        {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Email = Session["email"];
            ViewBag.Title = "Osobni podaci";
            var studentId = (int)Session["userId"];
            var user = _userRepository.GetById(studentId);

            if (user == null || !UserServices.IsUserStudent(user))
                return RedirectToAction("Index", "Home");

            return View(new StudentViewModel((Student)user));

        }

    }
}