using AutoMapper;
using MediatR;
using PdsCleanAppCore.Common.Exceptions;
using PdsCleanAppCore.Common.Interfaces;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppCore.Platform.Example.Commands.PutStudent
{
    public class PutStudentCmdHandler : IRequestHandler<PutStudentCmd, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public PutStudentCmdHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(PutStudentCmd request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Students.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            _mapper.Map(request.StudentDto, entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
