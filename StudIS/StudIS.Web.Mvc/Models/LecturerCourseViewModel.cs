using StudIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Mvc.Models {
    public class LecturerCourseViewModel {

        public int Id { get; set; }
        public string NaturalIdentifier { get; set; }
        public string Name { get; set; }
        public int EctsCredits { get; set; }

        public LecturerCourseViewModel() {

        }
        public LecturerCourseViewModel(Course course) {
            Id = course.Id;
            NaturalIdentifier = course.NaturalIdentifier;
            Name = course.Name;
            EctsCredits = course.EctsCredits;
        }
    }
}