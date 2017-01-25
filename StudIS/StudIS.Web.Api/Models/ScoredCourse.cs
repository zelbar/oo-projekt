using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Api.Models
{
    public class ScoredCourse
    {
        public String Name { get; set; }
        public List<SimpleScore> ScoreList { get; set; }
    }
}