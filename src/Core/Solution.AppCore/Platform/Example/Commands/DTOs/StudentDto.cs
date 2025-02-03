using AutoMapper;
using PdsCleanAppCore.Common.Mappings;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppCore.Platform.Example.Commands.DTOs
{
    public class StudentDto : IMapFrom<Student>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public List<StudentToCourse>? StudentToCourses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
