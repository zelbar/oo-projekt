using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models.Users
{
    public class Professor:User
    {
        public virtual IList<Course> CoruseList { get; set; }
    }
}
