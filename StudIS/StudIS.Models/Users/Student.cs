using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models
{
    public class Student : User
    {
        public virtual string JMBAG { get; set; }
        public virtual IList<Course> CoruseList { get; set; }
    }
}
