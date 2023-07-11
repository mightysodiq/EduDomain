namespace EduDomain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StudentAddressId { get; set; }
        public StudentAddress Address { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}