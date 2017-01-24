using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Mvc.Models
{
    public class ScoredCourseViewModel
    {
        public String Name { get; set; }
        public List<ScoreViewModel> scoreList{get;set;}
    }
}