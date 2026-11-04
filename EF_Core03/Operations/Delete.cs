using EF_Core03.Contexts;
using EF_Core03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Operations
{
    internal static class Delete
    {

        public static async Task DeleteEnrollment(OnlineLearningPlatform dbContext, int courseId, int studentId)
        {

            var enrollment = await dbContext.Enrollments.FindAsync(new object[] { courseId, studentId });
            if (enrollment is not null)
            {
                dbContext.Enrollments.Remove(enrollment);
                await dbContext.SaveChangesAsync();
                return;
            }

            Console.WriteLine("Invalid data");
        }
       public static async Task DeleteCourse(OnlineLearningPlatform dbContext, int courseId)
        {
            var course = await dbContext.Courses.FindAsync(courseId);
            var enrollments =  dbContext.Enrollments.Where(enroll=>enroll.CourseId==courseId);

            Console.WriteLine($"Befor Deletion enrollments = {enrollments.Count()}");
            if (course is not null)
            {
                dbContext.Courses.Remove(course);
                await dbContext.SaveChangesAsync();

                var enrollmentsAfter = dbContext.Enrollments.Where(enroll => enroll.CourseId == courseId);
                Console.WriteLine($"After Deletion enrollments = {enrollments.Count()}");

                return;
            }
        }
    }
}
