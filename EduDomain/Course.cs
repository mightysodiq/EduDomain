using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduDomain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public  ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
