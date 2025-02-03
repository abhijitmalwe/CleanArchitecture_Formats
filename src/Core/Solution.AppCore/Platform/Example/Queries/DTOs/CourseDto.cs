using PdsCleanAppCore.Common.Mappings;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppCore.Platform.Example.Queries.DTOs
{
    public class CourseDto : IMapFrom<Course>
    {

        public int Id { get; set; }
        public string? CourseName { get; set; }
    }
}
