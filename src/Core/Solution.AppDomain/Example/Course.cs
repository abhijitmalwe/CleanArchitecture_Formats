using PdsCleanAppDomain._Common;

namespace PdsCleanAppDomain.Example
{
    public class Course : AuditableEntity
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }

        public ICollection<Student>? Students { get; set; }
        public List<StudentToCourse>? StudentToCourses { get; set; }
    }
}
