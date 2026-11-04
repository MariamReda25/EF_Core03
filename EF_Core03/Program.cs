using EF_Core03.Contexts;
using EF_Core03.Models;
using EF_Core03.Operations;
using Microsoft.VisualBasic;

namespace EF_Core03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using OnlineLearningPlatform dbContext = new OnlineLearningPlatform();

            #region Create
            //await Create.AddInstructor(dbContext, new Instructor()
            //{
            //    FullName = "Ahmed Ramdan",
            //    Email = "Ahmed@Mail.com"
            //});

            //await Create.AddCategory(dbContext, new Category()
            //{
            //    Name = "Programming",
            //    Description = "Online Programming Courses"
            //});


            //await Create.AddNewCourse(dbContext, new Course()
            //{
            //    Title = "Backed ASP.NET",
            //    CategoryId = 1,
            //    Price = 6500,
            //    Level = "Intermediate",
            //    IsPublished = false
            //});


            //await Create.AddStudents(dbContext, new Student()
            //{
            //    FullName = "Malak Ahmed",
            //    DOB = DateTime.Now,
            //    Email = "Malak@mail.com"

            //}, new Student()
            //{
            //    FullName = "Sara Kamal",
            //    DOB = DateTime.Now,
            //    Email = "sara55@mail.com"

            //}, new Student()
            //{
            //    FullName = "Omar Ahmed",
            //    DOB = DateTime.Now,
            //    Email = "omar67@mail.com"

            //});


            //await Create.EnrollCourse(dbContext, 1, 2);

            #endregion


            #region Read

            // 1.
            // var course = await Read.GetCourseById(dbContext, 2);
            // if(course is null)
            //    Console.WriteLine("Not Found");
            //else
            //    Console.WriteLine(course.Title);

            // 2.
            //var course = await Read.GetCourseByTitle(dbContext, "Backed ASP.NET");
            //if (course is null)
            //    Console.WriteLine("Not Found");
            //else
            //    Console.WriteLine(course.Id);


            // 3.
            //await Read.FilterCourse(dbContext, 6000, 10000);


            // 4.
            //Read.GetbyCategories(dbContext, 1);

            //await Read.CourseRoster(dbContext,2);
            #endregion

            #region Update
            //await Update.UpdateCoursePrice(dbContext, 2, 8000);
            //await Update.UpdateProgress(dbContext, 2, 1,200);
            //await Update.PublishCourse(dbContext, 2, 1);
            #endregion


            #region Delete
            //await Delete.DeleteEnrollment(dbContext, 2, 1);

            // According to OnDelete Rule is ONCASCADE enrollments that contain this courseid will be deleted
            //await Delete.DeleteCourse(dbContext, 2);


            #endregion
        }


    }
}
