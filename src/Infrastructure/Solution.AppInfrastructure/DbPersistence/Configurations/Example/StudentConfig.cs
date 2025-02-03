using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdsCleanAppDomain.Example;

namespace PdsCleanAppInfrastructure.DbPersistence.Configurations.Example
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // * Table and primary key configuration *
            builder.ToTable(name: "Student", schema: "example").HasKey(pk => pk.Id);
            builder.ToTable(name: "Student", schema: "example").Property(pk => pk.Id).HasColumnName("Id").UseIdentityColumn();

            // * Table columns configuration *
            builder.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(100);
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(100);
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(100);


            // * Configure common properties *
            builder.Property(p => p.Active).HasColumnName("Active");
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            builder.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");

            // * Configure relationships*
            builder.HasMany(c => c.Courses)
                .WithMany(s => s.Students)
                .UsingEntity<StudentToCourse>();
        }
    }
}
