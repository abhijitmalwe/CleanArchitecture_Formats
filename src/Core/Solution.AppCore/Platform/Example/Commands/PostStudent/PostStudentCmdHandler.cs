using AutoMapper;
using MediatR;
using PdsCleanAppCore.Common.Interfaces;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppCore.Platform.Example.Commands.PostStudent
{
    public class PostStudentCmdHandler : IRequestHandler<PostStudentCmd, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public PostStudentCmdHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(PostStudentCmd request, CancellationToken cancellationToken)
        {
            var std = await _applicationDbContext.Students.AddAsync(_mapper.Map<Student>(request.StudentDto), cancellationToken);

            if (await _applicationDbContext.SaveChangesAsync(cancellationToken) > 0)
            {
                return std.Entity.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}