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
        Course GetById(int id);
        Course GetByNaturalIdentifier(string naturalIdentifier);
        IList<Course> GetByUser(User user);
        bool DeleteById(int id);
        bool DeleteByNaturalIdentifier(string naturalIdentifier);
        Course Update(Course course);
        Course Create(Course course);
    }
}
