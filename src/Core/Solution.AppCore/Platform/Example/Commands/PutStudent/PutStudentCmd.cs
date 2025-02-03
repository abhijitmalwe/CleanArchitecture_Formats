using MediatR;
using PdsCleanAppCore.Platform.Example.Commands.DTOs;

namespace PdsCleanAppCore.Platform.Example.Commands.PutStudent
{
    public class PutStudentCmd : IRequest<int>
    {
        public int Id { get; set; }
        public StudentDto? StudentDto { get; set; }
    }
}
