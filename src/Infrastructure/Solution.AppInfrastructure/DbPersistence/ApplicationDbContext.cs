using Microsoft.EntityFrameworkCore;
using PdsCleanAppCore.Common.Interfaces;
using PdsCleanAppDomain.Example;
using PdsCleanAppInfrastructure.Interceptors;
using System.Reflection;

namespace PdsCleanAppInfrastructure.DbPersistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<StudentToCourse> StudentToCourses => Set<StudentToCourse>();

        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(dbContextOptions)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // define default schema name 
            builder.HasDefaultSchema("app");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
