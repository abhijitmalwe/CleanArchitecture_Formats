using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppInfrastructure.DbPersistence.Configurations.Example
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // * Table and primary key configuration *
            builder.ToTable(name: "Course", schema: "example").HasKey(pk => pk.Id);
            builder.ToTable(name: "Course", schema: "example").Property(pk => pk.Id).HasColumnName("Id").UseIdentityColumn();

            // * Table columns configuration *
            builder.Property(p => p.CourseName).HasColumnName("CourseName").HasMaxLength(100);

            // * Configure common properties *
            builder.Property(p => p.Active).HasColumnName("Active");
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            builder.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");

            // * Configure relationships*
            builder.HasMany(s => s.Students)
                .WithMany(c => c.Courses)
                .UsingEntity<StudentToCourse>();
        }
    }
}
