//tinfo200:[2021-02-27-shalim01-dykstra1] -- Creation of Enrollment class that pertains to the student's enrollment information (of a certain course). There are 5 accessors info.
namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
    }
}