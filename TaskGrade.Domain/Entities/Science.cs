using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGrade.Domain.Entities
{
    public class Science
    {
        public Science()
        {
            Grades = new HashSet<Grade>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
