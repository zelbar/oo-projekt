using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using FluentNHibernate.Mapping;

namespace StudIS.DAL.Mappings
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.NaturalIdentifier)
                .Not.Nullable().Unique();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.EctsCredits).Not.Nullable();
            HasMany(x => x.Components).LazyLoad().Cascade.All();
            HasManyToMany(x => x.LecturersInCharge).LazyLoad();
            HasManyToMany(x => x.StudentsEnrolled).LazyLoad();
        }
    }
}
