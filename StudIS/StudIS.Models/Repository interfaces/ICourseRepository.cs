using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.Users;

namespace StudIS.Models.RepositoryInterfaces
{
    public interface ICourseRepository
    {
        IList<Course> GetAll();
        Course GetById(int id);
        Course GetByNaturalIdentifier(string naturalIdentifier);
        IList<Course> GetByUserId(int userId);
        IList<Course> GetByLecturerInChargerId(int lecturerId);
        bool DeleteById(int id);
        bool DeleteByNaturalIdentifier(string naturalIdentifier);
        Course Update(Course course);
        Course Create(Course course);
    }
}
