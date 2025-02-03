using AutoMapper;
using Dapper;
using MediatR;
using PdsCleanAppCore.Common.Interfaces;
using PdsCleanAppCore.Platform.Example.Commands.DTOs;

namespace PdsCleanAppCore.Platform.Example.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IDapperSqlConnectionService _dapperConnectionService;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IDapperSqlConnectionService dapperConnectionService, IMapper mapper)
        {
            _dapperConnectionService = dapperConnectionService;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            // get dapaer connection
            using var connection = _dapperConnectionService.GetDapperConnection();
            var parameters = new { id = request.Id };
            var sql = "select * from example.student where id = @id";
            var result = await connection.QuerySingleOrDefaultAsync<StudentDto>(sql, parameters);

            return result;
        }
    }
}
