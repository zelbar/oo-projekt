using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;

namespace StudIS.DAL.Repositories
{
    interface IUserRepository
    {
        User getById(int id);
        User getByEmail(string email);
        User getByNationalIdentificationNumbe(string nationalIdentificationNumbe);
        IList<User> getByCourse(Course course);
        bool deleteById(int id);
        bool deleteByNationalIdentificationNumbe(string nationalIdentificationNumbe);
        User update(User user);
        User create(User user);
        
    }
}
