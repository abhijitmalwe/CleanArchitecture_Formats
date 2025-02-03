using Microsoft.EntityFrameworkCore;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppCore.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        #region example
        DbSet<Student> Students { get; }
        DbSet<Course> Courses { get; }
        DbSet<StudentToCourse> StudentToCourses { get; }
        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
