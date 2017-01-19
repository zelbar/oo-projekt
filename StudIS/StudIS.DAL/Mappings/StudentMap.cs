using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.Users;
using FluentNHibernate.Mapping;

namespace StudIS.DAL.Mappings
{
    public class StudentMap : SubclassMap<Student>
    {
        public StudentMap()
        {
            DiscriminatorValue("student");

            Map(x => x.StudentIdentificationNumber);
            //References(x => x.CoursesEnrolledIn);
            HasMany(x => x.CoursesEnrolledIn);
        }
    }
}
