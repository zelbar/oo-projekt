using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models
{
    public class Course
    {
        public virtual int Id { get; set; }
        public virtual string NaturalIdentifier { get; set; }
        public virtual string Name { get; set; }
        public virtual int EctsCredits { get; set; }

        public virtual IList<Users.Lecturer> LecturersInCharge { get; set; }
        public virtual IList<Users.Student> StudentsEnrolled { get; set; }
        public virtual IList<Assessment> Assessments { get; set; }
    }
}
