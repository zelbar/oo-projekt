using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Mvc.Models {
    public class ComponentStatisticsViewModel {
        public virtual string ComponentName { get; set; }
        public virtual float Average { get; set; }
        public virtual float Max { get; set; }
        public virtual float Percentage { get; set; }
        public virtual int CourseId { get; set; }
        public ComponentStatisticsViewModel(string ComponentName, float Average, float Max, int CourseId) {
            this.ComponentName = ComponentName;
            this.Average = Average;
            this.Max = Max;
            this.Percentage = (float)Average / Max * 100;
            this.CourseId = CourseId;
        }
    }
}