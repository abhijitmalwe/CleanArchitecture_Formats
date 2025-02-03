using PdsCleanAppDomain.Example;

namespace PdsCleanAppInfrastructure.DbPersistence
{
    public class ApplicationDbContextInitialiser
    {
        public static async Task SeedDefaultStudentCourseDataAsync(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Students.Any())
            {
                await applicationDbContext.Students.AddRangeAsync(
                    new Student
                    {
                        FirstName = "Shaylynn"
                        ,
                        LastName = "Mariel"
                        ,
                        Email = "smariel0@foxnews.com"
                        ,
                        CreatedBy = "1"
                        ,
                        CreatedDate = DateTime.UtcNow
                        ,
                        ModifiedBy = "1"
                        ,
                        ModifiedDate = DateTime.UtcNow
                        ,
                        Active = true
                    }
                    , new Student
                    {
                        FirstName = "Burnard"
                        ,
                        LastName = "Jolliss"
                        ,
                        Email = "bjolliss1@tinypic.com"
                        ,
                        CreatedBy = "1"
                        ,
                        CreatedDate = DateTime.UtcNow
                        ,
                        ModifiedBy = "1"
                        ,
                        ModifiedDate = DateTime.UtcNow
                        ,
                        Active = true
                    }
                    , new Student
                    {
                        FirstName = "Ross"
                        ,
                        LastName = "Fairbeard"
                        ,
                        Email = "rfairbeard4@bigcartel.com"
                        ,
                        CreatedBy = "1"
                        ,
                        CreatedDate = DateTime.UtcNow
                        ,
                        ModifiedBy = "1"
                        ,
                        ModifiedDate = DateTime.UtcNow
                        ,
                        Active = true
                    });

                await applicationDbContext.SaveChangesAsync(cancellationToken: default);
            }

            if (!applicationDbContext.Courses.Any())
            {
                await applicationDbContext.Courses.AddRangeAsync(
                    new Course
                    {
                        CourseName = "Big Data"
                        ,
                        CreatedBy = "1"
                        ,
                        CreatedDate = DateTime.UtcNow
                        ,
                        ModifiedBy = "1"
                        ,
                        ModifiedDate = DateTime.UtcNow
                        ,
                        Active = true
                    }
                    , new Course
                    {
                        CourseName = "Cloud Computing"
                        ,
                        CreatedBy = "1"
                        ,
                        CreatedDate = DateTime.UtcNow
                        ,
                        ModifiedBy = "1"
                        ,
                        ModifiedDate = DateTime.UtcNow
                        ,
                        Active = true
                    });

                await applicationDbContext.SaveChangesAsync(cancellationToken: default);
            }

            if (!applicationDbContext.StudentToCourses.Any())
            {
                await applicationDbContext.StudentToCourses.AddRangeAsync(
                    new StudentToCourse { StudentId = 1, CourseId = 1 }
                    , new StudentToCourse { StudentId = 1, CourseId = 2 }
                    , new StudentToCourse { StudentId = 2, CourseId = 2 });

                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
