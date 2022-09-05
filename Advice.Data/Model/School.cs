using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advice.Data.Model
{
    public class School : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }

        public School()
        {
            Students = new();
            Teachers = new();
        }
    }
}
