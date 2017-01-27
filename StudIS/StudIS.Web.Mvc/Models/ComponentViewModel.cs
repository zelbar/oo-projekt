using StudIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Mvc.Models {
    public class ComponentViewModel {

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual float MaximumPoints { get; set; }
        public virtual float MinimumPointsToPass { get; set; }
        public virtual int CourseId { get; set; }
        public virtual string CourseName { get; set; }

        public ComponentViewModel() {

        }

        public ComponentViewModel(Component component) {
            this.Id = component.Id;
            this.Name = component.Name;
            this.MaximumPoints = component.MaximumPoints;
            this.MinimumPointsToPass = component.MinimumPointsToPass;
            this.CourseId = component.Course.Id;
            this.CourseName = component.Course.Name;
        }

    }
}