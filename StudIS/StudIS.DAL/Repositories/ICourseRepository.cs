using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;

namespace StudIS.DAL.Repositories
{
    interface ICourseRepository
    {
        Course getById(int id);
        Course getByNaturalIdentifier(string naturalIdentifier);
        IList<Course> getByUser(User user);
        bool deleteById(int id);
        bool deleteByNaturalIdentifier(string naturalIdentifier);
        Course update(Course course);
        Course create(Course course);
    }
}
