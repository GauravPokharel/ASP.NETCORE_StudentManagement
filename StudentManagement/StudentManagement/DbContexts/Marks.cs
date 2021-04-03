using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.DbContexts
{
    public class Marks
    {
        public int MarksId { get; set; }
        public int Mark { get; set; }
        public string UserId { get; set; }
        public int SubjectId { get; set; }
    }
    
}
