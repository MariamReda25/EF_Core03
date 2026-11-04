using EF_Core03.Contexts;
using EF_Core03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Operations
{
    internal static class Update
    {
        public static async Task UpdateCoursePrice(OnlineLearningPlatform dbContext,int courseId,decimal newPrice)
        {
            var course =await dbContext.Courses.FindAsync(courseId);

            if(course is not null)
            {
                course.Price = newPrice;

                await dbContext.SaveChangesAsync();

                Console.WriteLine("Data updated successfully");
                return;
            }
            Console.WriteLine("Invalid courseId");
        }

        public static async Task UpdateProgress(OnlineLearningPlatform dbContext,int courseId,int studnetId,int progress)
        {
            if (progress > 100 || progress < 0)
            {

                Console.WriteLine("Invalid Progress");
                return;
            }

            var enrollment = await dbContext.Enrollments.FindAsync(new object[] { courseId, studnetId });
           
            if(enrollment is not null)
            {
                enrollment.ProgressPercent = progress;
                if (progress == 100)
                    enrollment.Status = "Completed";

                await dbContext.SaveChangesAsync();
                Console.WriteLine("Data updated successfully");
                return;
            }

            Console.WriteLine("Invalid Enrollment");

        }

        public static async Task PublishCourse(OnlineLearningPlatform dbContext, int CourseId, int InstructorId)
        {
            var IsExistingInstructor = dbContext.Instructors.Any(Insructor => Insructor.Id == InstructorId);

            if (!IsExistingInstructor)
            {
                Console.WriteLine("Invalid Instructor ");
                return;
            }
            var IsExistingCourse = dbContext.Courses.Any(Course => Course.Id == CourseId);
            if (!IsExistingCourse)
            {
                Console.WriteLine("Invalid Course ");
                return;
            }

            var PublishedCourse = new PublishedCourses()
            {
                PublisherId = InstructorId,
                PublisheCourseId = CourseId
            };

            var course =await dbContext.Courses.FindAsync(CourseId);
            course.IsPublished = true;


            dbContext.PublishedCourses.Add(PublishedCourse);
            dbContext.Courses.Update(course);
            await dbContext.SaveChangesAsync();

            Console.WriteLine($"Course published successfully with Id {PublishedCourse.PublisheCourseId}");

        }
    }
}
