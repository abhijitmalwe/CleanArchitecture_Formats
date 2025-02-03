using MediatR;
using PdsCleanAppCore.Platform.Example.Commands.DTOs;

namespace PdsCleanAppCore.Platform.Example.Commands.PostStudent
{
    public class PostStudentCmd : IRequest<int>
    {
        public StudentDto? StudentDto { get; set; }
    }
}
