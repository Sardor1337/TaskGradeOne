using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGrade.Domain.Enums;

namespace TaskGrade.Domain.Entities
{
    public class User
    {
        public User()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public UserRole UserRole { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
