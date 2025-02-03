using PdsCleanAppDomain._Common;

namespace PdsCleanAppDomain.Example
{
    public class Student : AuditableEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public ICollection<Course>? Courses { get; set; }
        public List<StudentToCourse>? StudentToCourses { get; set; }
    }
}
