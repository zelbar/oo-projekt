using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models.Users
{
    public class Student : User
    {
        public virtual string StudentIdentificationNumber { get; set; }
        public virtual IList<Course> CoursesEnrolledIn { get; set; }
    }
}
