using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppInfrastructure.DbPersistence.Configurations.Example
{
    public class StudentToCourseConfig : IEntityTypeConfiguration<StudentToCourse>
    {
        public void Configure(EntityTypeBuilder<StudentToCourse> builder)
        {
            // * Table and primary key configuration *
            builder.ToTable(name: "StudentToCourse", schema: "example").HasKey(pk => pk.Id);
            builder.ToTable(name: "StudentToCourse", schema: "example").Property(pk => pk.Id).HasColumnName("Id").UseIdentityColumn();

            // * Table columns configuration *
            builder.Property(p => p.StudentId).HasColumnName("StudentId");
            builder.Property(p => p.CourseId).HasColumnName("CourseId");

            // * Configure relationships *

            builder.HasOne<Student>()
                .WithMany(st => st.StudentToCourses)
                .HasForeignKey(fk => fk.StudentId)
                .HasPrincipalKey(pk => pk.Id);

            builder.HasOne<Course>()
                .WithMany(st => st.StudentToCourses)
                .HasForeignKey(fk => fk.CourseId)
                .HasPrincipalKey(pk => pk.Id);

            //builder.HasOne(p => p.Student)
            //    .WithMany(p => p.StudentToCourses)
            //    .HasForeignKey(fk => fk.StudentId)
            //    .HasPrincipalKey(pk => pk.Id);

            //builder.HasOne(p => p.Course)
            //    .WithMany(p => p.StudentToCourses)
            //    .HasForeignKey(fk => fk.CourseId)
            //    .HasPrincipalKey(pk => pk.Id);
        }
    }
}
