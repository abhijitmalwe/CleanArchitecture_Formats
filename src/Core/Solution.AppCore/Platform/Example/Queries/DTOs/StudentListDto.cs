using PdsCleanAppCore.Common.Mappings;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppCore.Platform.Example.Queries.DTOs
{
    public class StudentListDto : IMapFrom<Student>
    {
        public StudentListDto()
        {
            Courses = new List<CourseDto>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public ICollection<CourseDto>? Courses { get; set; }
    }
}
