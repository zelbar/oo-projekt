using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models
{
    public class Score
    {
        public virtual int Id { get; set; }
        public virtual float Value { get; set; }
        public virtual Component Component { get; set; }
        public virtual Users.Student Student { get; set; }
    }
}
