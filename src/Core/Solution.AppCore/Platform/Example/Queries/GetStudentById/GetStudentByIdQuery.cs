using MediatR;
using PdsCleanAppCore.Platform.Example.Commands.DTOs;

namespace PdsCleanAppCore.Platform.Example.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}
