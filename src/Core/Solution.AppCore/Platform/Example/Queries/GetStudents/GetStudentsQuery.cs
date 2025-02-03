using MediatR;
using PdsCleanAppCore.Common.Models;
using PdsCleanAppCore.Platform.Example.Queries.DTOs;

namespace PdsCleanAppCore.Platform.Example.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<PaginatedList<StudentListDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
