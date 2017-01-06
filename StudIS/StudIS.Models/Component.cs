using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models
{
    public class Component
    {
        public virtual int Id { get; set; }
        public virtual int CourseId { get; set; }
        public virtual string Name { get; set; }
        public virtual float MaximumPoints { get; set; }
        public virtual float MinimumPointsToPass { get; set; }
    }
}
