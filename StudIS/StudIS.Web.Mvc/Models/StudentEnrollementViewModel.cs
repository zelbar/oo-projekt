using StudIS.Models;
using StudIS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Mvc.Models {
    public class StudentEnrollementViewModel {
        public IList<Score> scores { get; set; }
        public StudentEnrollementViewModel() {
        }
        public StudentEnrollementViewModel(IList<Score> scores) {
            this.scores = new List<Score>();
            this.scores.Concat(scores);
        }

    }
}