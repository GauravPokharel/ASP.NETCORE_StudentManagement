using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MarksModel
    {
        public int Id { get; set; }
        public int Marks { get; set; }
        public double Percentage { get; set; }
        public string UserId { get; set; }
        public int SubjectId { get; set; }
        public subjects SubjectN { get; set; }
    }
    public class subjects
    {
        public string SubjectName { get; set; }
    }
}
