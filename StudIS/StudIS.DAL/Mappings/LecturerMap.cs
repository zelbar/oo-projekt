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
    public class LecturerMap : SubclassMap<Lecturer>
    {
        public LecturerMap()
        {
            DiscriminatorValue("lecturer");

            HasManyToMany(x => x.CoursesInChargeOf);
        }
    }
}
