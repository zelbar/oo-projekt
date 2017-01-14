using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using FluentNHibernate.Mapping;

namespace StudIS.DAL.Mappings
{
    public class ScoreMap : ClassMap<Score>
    {
        public ScoreMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Value).Not.Nullable();
            References(x => x.Component).LazyLoad();
            References(x => x.Student).LazyLoad();
        }
    }
}
