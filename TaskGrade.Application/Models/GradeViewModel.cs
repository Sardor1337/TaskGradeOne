using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGrade.Application.Models
{
    public class GradeViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int ScienceId { get; set; }
        public int GradePresent { get; set; }
    }
}
