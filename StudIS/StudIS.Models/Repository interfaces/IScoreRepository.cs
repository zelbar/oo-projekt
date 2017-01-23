using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models.RepositoryInterfaces
{
    public interface IScoreRepository
    {
        //IList<Score> GetByStudentAndCourse(int studentId, int CourseId);
        Score Create(Score score);
        Score Update(Score score);
        Score CreateOrUpdate(Score score);
        Score GetById(int id);
        Score GetByStudentIdAndComponentId(int studentId, int componentId);
    }
}
