using PdsCleanAppCore.Common.Mappings;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppCore.Platform.Example.Commands.DTOs
{
    public class StudentToCourseDto : IMapFrom<StudentToCourse>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
