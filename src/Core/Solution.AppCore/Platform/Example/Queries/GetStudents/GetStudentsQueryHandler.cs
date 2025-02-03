using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PdsCleanAppCore.Common.Interfaces;
using PdsCleanAppCore.Common.Mappings;
using PdsCleanAppCore.Common.Models;
using PdsCleanAppCore.Platform.Example.Queries.DTOs;

namespace PdsCleanAppCore.Platform.Example.Queries.GetStudents
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, PaginatedList<StudentListDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetStudentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<PaginatedList<StudentListDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            //var res = await _applicationDbContext.Students.Include(c => c.Courses).ToListAsync(cancellationToken: cancellationToken);

            return await _applicationDbContext.Students
                .Include(c => c.Courses)
                .OrderBy(s => s.Id)
                .ProjectTo<StudentListDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
